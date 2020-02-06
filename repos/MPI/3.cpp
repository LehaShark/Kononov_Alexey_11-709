//#include <mpi.h>
//#include <iostream>
//#include <cmath>
//#include <algorithm>
//
//#ifndef ROOT_RANK
//#define ROOT_RANK 0
//#endif
//#ifndef MAX_ARRAY_SIZE
//#define MAX_ARRAY_SIZE 100
//#endif
//
//int main(int argc, char const* argv[])
//{
//	// Start mpi
//	int size = 1000000;
//	int rank, comm_size;
//	int innerCount = 0;
//	double x, y;
//	MPI_Init(NULL, NULL);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &comm_size);
//	srand(rank);
//	int partition = size / comm_size;
//	int mpiInnerCount = 0;
//	for (int i = rank * partition; i < rank * partition + partition; i++)
//	{
//		x = (double)rand() / (double)RAND_MAX * 2 - 1;
//		y = (double)rand() / (double)RAND_MAX * 2 - 1;
//		if (pow(x, 2) + pow(y, 2) <= 1)
//			mpiInnerCount++;
//	}
//	printf("Sending %d to rank 0 from rank %d\n", mpiInnerCount, rank);
//	MPI_Reduce(&mpiInnerCount, &innerCount, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
//	if (rank == 0)
//	{
//		double answer = (double)(4 * innerCount) / (double)size;
//		printf("Pi = %f  %d", answer, innerCount);
//	}
//	MPI_Finalize();
//}
