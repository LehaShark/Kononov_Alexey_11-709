//#include <mpi.h>
//#include <stdio.h>
//#include <xlocinfo>
//#include <time.h>
//
//int main(int argc, char** argv) {
//	// Start mpi
//	int arrSize = 100;
//
//	int rank, comm_size;
//
//	unsigned long long int sum = 0;
//	unsigned long long int receiveReduce;
//
//	MPI_Init(NULL, NULL);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &comm_size);
//
//	int partition = arrSize / comm_size;
//	int* arrX = new int[arrSize];
//	int* arrY = new int[arrSize];
//	int* receivebufX = new int[partition];
//	int* receivebufY = new int[partition];
//	int* sendcounts = new int[comm_size];
//	int* displs = new int[comm_size];
//	if (rank == 0)
//	{
//		printf("Partition = %d\n", partition);
//		srand(time(NULL));
//		for (int i = 0; i < arrSize; i++)
//		{
//			arrX[i] = rand();
//			arrY[i] = rand();
//		}
//		for (int i = 0; i < comm_size; ++i) {
//			displs[i] = i * partition;
//			sendcounts[i] = partition;
//		}
//		printf("Scattering...\n");
//	}
//	MPI_Scatterv(arrX, sendcounts, displs, MPI_INT, receivebufX, partition, MPI_INT, 0, MPI_COMM_WORLD);
//	MPI_Scatterv(arrY, sendcounts, displs, MPI_INT, receivebufY, partition, MPI_INT, 0, MPI_COMM_WORLD);
//	MPI_Barrier(MPI_COMM_WORLD);
//	for (int i = 0; i < partition; i++)
//	{
//		sum += (unsigned long long int)(receivebufX[i] * receivebufY[i]);
//	}
//	printf("Sending sum %llu to rank 0 from rank %d\n", sum, rank);
//	MPI_Reduce(&sum, &receiveReduce, 1, MPI_UNSIGNED_LONG_LONG, MPI_SUM, 0, MPI_COMM_WORLD);
//	if (rank == 0)
//	{
//		printf("ScalarMultiply = %llu\n", receiveReduce);
//	}
//	MPI_Finalize();
//
//	return (0);
//}