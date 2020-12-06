#include "opencv2/highgui.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/objdetect/objdetect.hpp"
#include "opencv2/video/tracking.hpp"
#include "opencv2/videoio.hpp"
#include <opencv2/core/mat.hpp>
#include <vector>
#include <iostream>


using namespace cv;
using namespace std;



int main(int argc, const char** argv)
{

    VideoCapture cap("autobahn.mp4");


    Mat flow, frame;
    // some faster than mat image container
    UMat  flowUmat, prevgray;

    for (;;)
    {

        bool Is = cap.grab();
        if (Is == false) {
            cout << "Video Capture Fail" << endl;
            break;
        }
        else {



            Mat img;
            Mat original;

            // capture frame from video file
            cap.retrieve(img, CAP_OPENNI_BGR_IMAGE);
            resize(img, img, Size(640, 480));

            // save original for later
            img.copyTo(original);

            // make current frame gray
            cvtColor(img, img, COLOR_BGR2GRAY);

            if (prevgray.empty() == false ) {

                // calculate optical flow
                calcOpticalFlowFarneback(prevgray, img, flowUmat, 0.4, 1, 12, 2, 8, 1.2, 0);
                // copy Umat container to standard Mat
                flowUmat.copyTo(flow);









                const int cluster_count = 9;

                cv::Mat src_mat = original;
                if(src_mat.empty()) return -1;

                std::vector<cv::Mat> channels;
                cv::split(src_mat, channels);

                const int rows = src_mat.rows * src_mat.cols;
                const int cols = channels.size();

                cv::Mat mat = cv::Mat::zeros(rows, cols, CV_8U);
                for(int col = 0; col < cols; ++col) {
                    // Применяю размытие с фильтром 4х4.
                    // Как оказалось, это даёт самый лучший результат.
                    // Больший размер фильтра размытия ведёт
                    // к большей деформации результата, так что 4х4 - это компромисс.
                    // Теория говорит про 2х2, поэтому решено ислользовать его.
                    cv::Mat blr_mat;
                    cv::blur(channels[col], blr_mat, cv::Size(4,4));

                    // Размытое изображение переформатируем в матрицу с одной колонкой.
                    blr_mat.reshape(1,rows).copyTo(mat.col(col));
                }

                mat.convertTo(mat, CV_32F);

                cv::Mat labels_mat;
                cv::kmeans(mat, cluster_count, labels_mat, cv::TermCriteria(), 1
                        , cv::KMEANS_PP_CENTERS);

                cv::convertScaleAbs(labels_mat.reshape(0,src_mat.rows)
                        , labels_mat, 255/cluster_count, 1);

                cv::imshow("s", labels_mat);












                for (int y = 0; y < original.rows; y += 5) {
                    for (int x = 0; x < original.cols; x += 5)
                    {
                        // get the flow from y, x position * 10 for better visibility
                        const Point2f flowatxy = flow.at<Point2f>(y, x) * 10;
                        // draw line at flow direction
                        line(original, Point(x, y), Point(cvRound(x + flowatxy.x), cvRound(y + flowatxy.y)), Scalar(255,0,0));
                        // draw initial point
                        circle(original, Point(x, y), 1, Scalar(0, 0, 0), -1);
                    }
                }

















                cv::Mat bw;
                cv::cvtColor(original, bw, COLOR_BGR2GRAY);
                cv::threshold(bw, bw, 40, 255, cv::THRESH_BINARY);

                //show
                cv::imshow("bw", bw);

                cv::Mat dist;
                cv::distanceTransform(bw, dist, cv::DIST_L2, 3);
                cv::normalize(dist, dist, 0, 1, cv::NORM_MINMAX);

                //show
                cv::imshow("dist", dist);

                cv::threshold(dist, dist, .5, 1., cv::THRESH_BINARY);

                //show
                cv::imshow("nextDist", dist);

                // Create the CV_8U version of the distance image
                // It is needed for cv::findContours()
                cv::Mat dist_8u;
                dist.convertTo(dist_8u, CV_8U);

                // Find total markers
                std::vector<std::vector<cv::Point> > contours;
                cv::findContours(dist_8u, contours, cv::RETR_EXTERNAL, cv::CHAIN_APPROX_SIMPLE);

                // Total objects
                int ncomp = contours.size();
                //cout<<ncomp;

                cv::Mat markers = cv::Mat::zeros(dist.size(), CV_32SC1);
                for (int i = 0; i < ncomp; i++){
                    cv::drawContours(markers, contours, i, cv::Scalar::all(i+1), -1);
                }

                cv::circle(markers, cv::Point(5,5), 3, CV_RGB(255,255,255), -1);

                cv::watershed(original, markers);

                // Generate random colors
                std::vector<cv::Vec3b> colors;
                for (int i = 0; i < ncomp; i++)
                {
                    int b = cv::theRNG().uniform(0, 255);
                    int g = cv::theRNG().uniform(0, 255);
                    int r = cv::theRNG().uniform(0, 255);
                    colors.push_back(cv::Vec3b((uchar)b, (uchar)g, (uchar)r));
                }
// Create the result image
                cv::Mat dst = cv::Mat::zeros(markers.size(), CV_8UC3);
// Fill labeled objects with random colors
                for (int i = 0; i < markers.rows; i++)
                {
                    for (int j = 0; j < markers.cols; j++)
                    {
                        int index = markers.at<int>(i,j);
                        if (index > 0 && index <= ncomp)
                            dst.at<cv::Vec3b>(i,j) = colors[index-1];
                        else
                            dst.at<cv::Vec3b>(i,j) = cv::Vec3b(0,0,0);
                    }
                }
                cv::imshow("dst", original);




                // draw the results
                namedWindow("prew", WINDOW_AUTOSIZE);
                imshow("prew", original);

                // fill previous image again
                img.copyTo(prevgray);

            }
            else {

                // fill previous image in case prevgray.empty() == true
                img.copyTo(prevgray);

            }

            int key1 = waitKey(20);

        }
    }
}

