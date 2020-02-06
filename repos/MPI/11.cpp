//#include <mpi.h>
//#include <stdio.h>
//#include <xlocinfo>
//
//void Task11(int number)
//{
//	int rank, comm_size;
//
//	MPI_Init(NULL, NULL);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &comm_size);
//
//	int a = number, b;
//
//	if (rank == 0)
//	{
//		
//		MPI_Send(&a, 1, MPI_INT, rank + 1, rank + 1, MPI_COMM_WORLD);
//	}
//	if (rank != 0)
//	{
//		MPI_Recv(&b, 1, MPI_INT, rank - 1, rank, MPI_COMM_WORLD, MPI_STATUSES_IGNORE);
//	
//		a = b * b;
//		if (rank != comm_size - 1)
//			MPI_Send(&a, 1, MPI_INT, rank + 1, rank + 1, MPI_COMM_WORLD);
//		else
//			MPI_Send(&a, 1, MPI_INT, 0, 0, MPI_COMM_WORLD);
//	}
//	if (rank == 0)
//	{
//		printf("end");
//		MPI_Recv(&b, 1, MPI_INT, comm_size - 1, 0, MPI_COMM_WORLD, MPI_STATUSES_IGNORE);
//		printf("Result = %d\n", b);
//	}
//	MPI_Finalize();
//}
//
//int main(int argc, char** argv) {
//	// Start mpi
//	Task11(100);
//
//	return (0);
//}
