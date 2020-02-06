//#include <iostream>
//#include <mpi.h>
//#include <climits>
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
//	MPI_Init(NULL, NULL);
//	int size;
//	int rank;
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	int lenght = std::atoi(argv[1]);
//	int arr[lenght];
//	int chunks[size];
//	int offsets[size];
//	// Initiating data
//	if (rank == ROOT_RANK) {
//		// Creating working array
//		for (int i = 0; i < lenght; i++)
//			arr[i] = std::rand() % lenght;
//		// First precision chunk's for processes
//		int left = lenght % size;
//		int chunk = lenght / size;
//		// Creating array of chunk's and offsets for sending
//		for (int i = 0; i < size; i++)
//		{
//			chunks[i] = chunk + (left > 0 ? 1 : 0);
//			if (i)
//				offsets[i] = offsets[i - 1] + chunks[i - 1];
//			else
//				offsets[i] = 0;
//			left--;
//		}
//	}
//	// Creating local working arrays
//	int work_len = lenght / size + (lenght % size > rank ? 1 : 0);
//	int work[work_len];
//
//	// Sending data
//	MPI_Scatterv(
//		&arr,
//		chunks,
//		offsets,
//		MPI_INT,
//		&work,
//		work_len,
//		MPI_INT,
//		ROOT_RANK,
//		MPI_COMM_WORLD
//	);
//	// Calculating
//	float summ = 0;
//	for (int i = 0; i < work_len; i++)
//		summ += work[i];
//	summ /= work_len;
//	// Synchonization
//	if (rank != ROOT_RANK)
//		MPI_Send(
//			&summ,
//			1,
//			MPI_FLOAT,
//			ROOT_RANK,
//			std::rand(),
//			MPI_COMM_WORLD
//		);
//	else {
//		float local;
//		MPI_Status status;
//		for (int i = 1; i < size; i++)
//		{
//			MPI_Recv(
//				&local,
//				1,
//				MPI_FLOAT,
//				MPI_ANY_SOURCE,
//				MPI_ANY_TAG,
//				MPI_COMM_WORLD,
//				&status
//			);
//			if (status.MPI_ERROR)
//				std::cout << "Error in reciev" << std::endl;
//			summ += local;
//		}
//		std::cout << summ / size << std::endl;
//	}
//
//	MPI_Finalize();
//	return EXIT_SUCCESS;
//}
