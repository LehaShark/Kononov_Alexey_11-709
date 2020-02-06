//#include <iostream>
//#include <mpi.h>
//#include <climits>
//#include <cmath>
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
//	int matrix[lenght][lenght];
//	int max = 0, min = 0;
//	// Chunks and Offsets to send
//	int chunks[size];
//	int offsets[size];
//	// Initiating data
//	if (rank == ROOT_RANK) {
//		// Creating working array
//		for (int i = 0; i < lenght; i++)
//			for (int j = 0; j < lenght; j++)
//				matrix[i][j] = std::rand() % lenght;
//		// First precision chunk's for processes
//		int left = lenght * lenght % size;
//		int chunk = lenght * lenght / size;
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
//	int work_len = lenght * lenght / size + (lenght * lenght % size > rank ? 1 : 0);
//	int work[work_len];
//
//	// Sending data
//	MPI_Scatterv(
//		&matrix,
//		chunks,
//		offsets,
//		MPI_INT,
//		&work,
//		work_len,
//		MPI_INT,
//		ROOT_RANK,
//		MPI_COMM_WORLD
//	);
//	// Searching
//	int local_min = 999999, local_max = 0;
//	for (int i = 0; i < work_len; i++) {
//		local_max = std::max(work[i], local_max);
//		local_min = std::min(work[i], local_min);
//	}
//	// Synchonization
//	MPI_Reduce(
//		&local_max,
//		&max,
//		1,
//		MPI_INT,
//		MPI_MIN,
//		ROOT_RANK,
//		MPI_COMM_WORLD
//	);
//	MPI_Reduce(
//		&local_min,
//		&min,
//		1,
//		MPI_INT,
//		MPI_MAX,
//		ROOT_RANK,
//		MPI_COMM_WORLD
//	);
//	if (rank == ROOT_RANK)
//		std::cout << min << " " << max << std::endl;
//
//	MPI_Finalize();
//	return EXIT_SUCCESS;
//}
