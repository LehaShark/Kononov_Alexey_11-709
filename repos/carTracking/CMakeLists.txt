cmake_minimum_required(VERSION 3.13)
project(newVector)

set(CMAKE_CXX_STANDARD 14)
find_package( OpenCV REQUIRED )
add_executable(newVector main.cpp)
target_link_libraries( newVector ${OpenCV_LIBS} )