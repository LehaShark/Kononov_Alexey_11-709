//#include <mpi.h>
//#include <stdio.h>
//#include <utility>
//#include <time.h>
//
//void task2(const int arrSize)
//{
//	int rank, comm_size;
//	int max = 0;
//	int maxReduce = 0;
//
//	MPI_Init(NULL, NULL);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &comm_size);
//
//	int partition = arrSize / comm_size;
//	int* arr = new int[arrSize];
//	int* receivebuf = new int[partition];
//	int* sendcounts = new int[comm_size];
//	int* displs = new int[comm_size];
//	if (rank == 0)
//	{
//		printf("Partition = %d\n", partition);
//		srand(time(NULL)); //random.
//		for (int i = 0; i < arrSize; i++)
//		{
//			arr[i] = rand();
//		}
//		for (int i = 0; i < comm_size; ++i) {
//			displs[i] = i * partition;
//			sendcounts[i] = partition;
//		}
//		printf("Scattering...\n");
//	}
//	MPI_Scatterv(arr, sendcounts, displs, MPI_INT, receivebuf, partition, MPI_INT, 0, MPI_COMM_WORLD);// раздаем каждому процессу в группе
//	MPI_Barrier(MPI_COMM_WORLD);// блокирует вызывающий процесс, пока все процессы группы не вызовут её
//	for (int i = 0; i < partition; i++)
//	{
//		if (receivebuf[i] > maxReduce) maxReduce = receivebuf[i];
//	}
//	printf("Sending max %d to rank 0 from rank %d\n", maxReduce, rank);
//	MPI_Reduce(&maxReduce, &max, 1, MPI_INT, MPI_MAX, 0, MPI_COMM_WORLD);// объединяет элементы буфера каждого процесса
//	if (rank == 0)
//	{
//		printf("Max = %d\n", max);
//	}
//	MPI_Finalize();
//}
//
//int main(int argc, char** argv) {
//
//	task2(10);
//	return (0);
//}