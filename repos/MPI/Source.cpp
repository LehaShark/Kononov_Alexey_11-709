//#include <mpi.h>
//#include <time.h>
//#include <iostream>
//#include <stdio.h>
//#include <algorithm>
//
//void Task4()
//{
//	MPI_Init(NULL, NULL);
//	const int N = 20;
//	int rank, size;
//	int a[N], min = -100, max = 100;
//	int sum_count[2], proc_sum_count[2];
//
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	srand(time(0));
//
//	//заполнение массива
//	if (rank == 0)
//	{
//		for (int i = 0; i < N; i++)
//		{
//			int random = min + (rand() % static_cast<int>(max - min + 1));
//			a[i] = random;
//
//			printf("[%d]", a[i]);
//		}
//	}
//
//	//разделяем на нное количество массивов
//	int* len = new int[size];
//	int* ind = new int[size];
//
//	int rest = N;
//	int k = rest / size;
//	len[0] = k;
//	ind[0] = 0;
//
//
//
//	for (int i = 1; i < size; i++) {
//		rest -= k;
//		k = rest / (size - i);
//		len[i] = k;
//		ind[i] = ind[i - 1] + len[i - 1];
//	}
//
//	int proc_num = len[rank];
//	int* proc_part = new int[proc_num];
//
//
//	//распределение данных. то что отправляем, длинна, и сами аргументы, область процессов и их кол-во
//	MPI_Scatterv(a, len, ind, MPI_INT, proc_part, proc_num,
//		MPI_INT, 0, MPI_COMM_WORLD);
//
//	proc_sum_count[0] = 0;
//	proc_sum_count[1] = 0;
//
//	//общая сумма
//	for (int i = 0; i < proc_num; i++) {
//		if (proc_part[i] > 0) {
//			proc_sum_count[0] += proc_part[i];
//			proc_sum_count[1]++;
//		}
//	}
//
//	//получаем обратно главному процессу
//	MPI_Reduce(&proc_sum_count, &sum_count, 2, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
//
//
//	// главный поток получил всю информацию делит на кол-во
//	if (rank == 0) {
//		printf("%d %d", sum_count[0], sum_count[1]);
//		double result = (double)sum_count[0] / sum_count[1];
//		printf("\nMiddle: %f", result);
//	}
//	MPI_Finalize();
//}
//
//void Task5()
//{
//	
//	MPI_Init(NULL, NULL);
//	const int N = 10;
//	int vect_a[N], vect_b[N], proc_mult_sum = 0, mult_sum = 0, test_sum = 0;
//	int rank, size;
//
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	srand(time(0));
//
//	//заполняем векторы
//	if (rank == 0) {
//		for (int i = 0; i < N; i++) {
//			vect_a[i] = rand() % 10;
//			vect_b[i] = rand() % 10;
//
//			printf("[%d] ", vect_a[i]);
//			printf("[%d] \n", vect_b[i]);
//
//			test_sum += vect_a[i] * vect_b[i];
//		}
//	}
//
//	int* len = new int[size];
//	int* ind = new int[size];
//
//	int rest = N;
//	int k = rest / size;
//	len[0] = k;
//	ind[0] = 0;
//
//	// распределяем для процессов
//	for (int i = 1; i < size; i++) {
//		rest -= k;
//		k = rest / (size - i);
//		len[i] = k;
//		ind[i] = ind[i - 1] + len[i - 1];
//	}
//
//	int 
//		
//		proc_num = len[rank];
//	int* vect_a_proc = new int[proc_num];
//	int* vect_b_proc = new int[proc_num];
//
//	
//	MPI_Scatterv(vect_a, len, ind, MPI_INT, vect_a_proc, proc_num,
//		MPI_INT, 0, MPI_COMM_WORLD);
//	MPI_Scatterv(vect_b, len, ind, MPI_INT, vect_b_proc, proc_num,
//		MPI_INT, 0, MPI_COMM_WORLD);
//
//
//	//подсчитываем скалярное произведение
//	proc_mult_sum = 0;
//	for (int i = 0; i < proc_num; i++) {
//		proc_mult_sum += vect_a_proc[i] * vect_b_proc[i];
//	}
//
//	//собираем обратно 
//	MPI_Reduce(&proc_mult_sum, &mult_sum, 1, MPI_INT, MPI_SUM, 0, MPI_COMM_WORLD);
//
//	if (rank == 0)
//	{
//		printf("\nscalar multiplication: %d", mult_sum);
//	}
//	MPI_Finalize();
//}
//
//void task6()
//{
//	MPI_Init(NULL, NULL);
//	int size;
//	int rank;
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//
//	const auto length = 200;
//	int matrix[length][length];
//	auto max = 0, min = 0;
//	const auto sendcounts = new int[size];
//	const auto displs = new int[size];
//	const auto partition = length / size;
//	srand(time(NULL));
//
//	if (rank == 0)
//	{
//		for (auto i = 0; i < length; i++)
//			for (auto j = 0; j < length; j++)
//				matrix[i][j] = rand();
//
//		auto left = length % size;
//		for (auto i = 0; i < size; i++, left--)
//		{
//			sendcounts[i] = (partition + (left > 0 ? 1 : 0))* length;
//			displs[i] = i ? displs[i - 1] + sendcounts[i - 1] : 0;
//		}
//	}
//
//	const auto rows_count = length / size + (length % size > rank ? 1 : 0);
//	const auto buff_length = rows_count * length;
//	const auto buff = new int[buff_length];
//
//	MPI_Scatterv(&matrix, sendcounts, displs, MPI_INT, buff,
//		buff_length, MPI_INT, 0, MPI_COMM_WORLD);
//
//	auto send_min = INT_MAX;
//	auto send_max = INT_MIN;
//	for (auto i = 0; i < rows_count; i++)
//	{
//		auto local_min = INT_MAX, local_max = INT_MIN;
//		for (auto j = 0; j < length; j++)
//		{
//			local_min = std::min(local_min, buff[i * length + j]);
//			local_max = std::max(local_max, buff[i * length + j]);
//		}
//		send_min = std::min(local_min, send_min);
//		send_max = std::max(local_max, send_max);
//	}
//
//	MPI_Reduce(&send_max, &max, 1, MPI_INT,
//		MPI_MIN, 0, MPI_COMM_WORLD);
//
//	MPI_Reduce(&send_min, &min, 1, MPI_INT,
//		MPI_MAX, 0, MPI_COMM_WORLD);
//
//	if (rank == 0)
//		printf("%d %d", min, max);
//
//	MPI_Finalize();
//}
//
//void task7()
//{
//	MPI_Init(NULL, NULL);
//	int size;
//	int rank;
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//
//	const auto length = 20;
//	int matrix[length][length];
//	const auto sendcounts = new int[size];
//	const auto displs = new int[size];
//	const auto vector = new int[length];
//	const auto vector_sendcounts = new int[size];
//	const auto vector_displs = new int[size];
//	const auto result = new int[length];
//	const auto partition = length / size;
//	srand(time(NULL));
//
//	if (rank == 0)
//	{
//		for (auto i = 0; i < length; i++)
//		{
//			vector[i] = rand() % 10;
//			for (auto j = 0; j < length; j++)
//				matrix[i][j] = rand() % 10;
//		}
//
//		for (auto i = 0; i < length; i++)
//			for (auto j = 0; j < i; j++)
//				std::swap(matrix[i][j], matrix[j][i]);
//
//		auto left = length % size;
//		for (auto i = 0; i < size; i++, left--)
//		{
//			sendcounts[i] = (partition + (left > 0 ? 1 : 0))* length;
//			displs[i] = i ? displs[i - 1] + sendcounts[i - 1] : 0;
//		}
//
//		left = length % size;
//		for (auto i = 0; i < size; i++, left--)
//		{
//			vector_sendcounts[i] = partition + (left > 0 ? 1 : 0);
//			vector_displs[i] = i ? vector_sendcounts[i - 1] + vector_displs[i - 1] : 0;
//		}
//	}
//
//	const auto columns = partition + (length % size > rank ? 1 : 0);
//	const auto buff_length = columns * length;
//	const auto buff = new int[buff_length];
//	const auto vector_buff = new int[columns];
//
//	MPI_Scatterv(&matrix, sendcounts, displs, MPI_INT,
//		buff, buff_length, MPI_INT, 0, MPI_COMM_WORLD);
//
//	MPI_Scatterv(vector, vector_sendcounts, vector_displs, MPI_INT,
//		vector_buff, columns, MPI_INT, 0, MPI_COMM_WORLD);
//
//	const auto send_to = new int[length];
//	for (auto i = 0; i < length; i++)
//		send_to[i] = 0;
//
//	for (auto i = 0; i < length; i++)
//		for (auto j = 0; j < columns; j++)
//			send_to[i] += buff[j * length + i] * vector_buff[j];
//
//	MPI_Reduce(send_to, result, length, MPI_INT,
//		MPI_SUM, 0, MPI_COMM_WORLD);
//
//	if (rank == 0)
//	{
//		for (auto i = 0; i < length; i++)
//			printf("%d ", result[i]);
//	}
//
//	MPI_Finalize();
//}
//
////void Task6() {
////
////	MPI_Init(NULL, NULL);
////	const int N = 10;
////	int rank, size, proc_n, proc_min_n;
////	int a[N * N];
////	int* proc_a, * proc_min_a;
////
////	int maxmin;
////
////	int* localmins = new int[N];
////
////	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
////	MPI_Comm_size(MPI_COMM_WORLD, &size);
////
////	srand(time(0));
////	//заполняем
////	if (rank == 0) {
////		for (int i = 0; i < N; i++) {
////			int localmin = 1000;
////			for (int j = 0; j < N; j++) {
////
////				int f = rand() % 1000;
////				a[i * N + j] = f;
////
////				if (f < localmin)
////					localmin = f;
////
////				printf("\t%d\t", a[i * N + j]);
////
////			}
////			printf(" local min: %d \n", localmin);
////			localmins[i] = 1000;
////		}
////
////	}
////	int* len = new int[size];
////	int* ind = new int[size];
////
////	int* len_min = new int[size];
////	int* ind_min = new int[size];
////
////	int rest = N;
////	int k = rest / size;
////	len[0] = k * N;
////	ind[0] = 0;
////
////	len_min[0] = k;
////	ind_min[0] = 0;
////
////	
////	for (int i = 1; i < size; i++) {
////		rest -= k;
////		k = rest / (size - i);
////		len[i] = k * N;
////		ind[i] = ind[i - 1] + len[i - 1];
////
////		len_min[i] = k;
////		ind_min[i] = ind_min[i - 1] + len_min[i - 1];
////	}
////	proc_n = len[rank];
////	proc_a = new int[proc_n];
////
////	proc_min_n = len_min[rank];
////	proc_min_a = new int[proc_min_n];
////
////	
////	MPI_Scatterv(a, len, ind, MPI_INT, proc_a, proc_n, MPI_DOUBLE,
////		0, MPI_COMM_WORLD);
////
////	MPI_Scatterv(localmins, len_min, ind_min, MPI_INT, proc_min_a, proc_min_n, MPI_DOUBLE,
////		0, MPI_COMM_WORLD);
////
////	//вычисляем
////	for (int i = 0; i < proc_n / N; i++) {
////
////		for (int j = 0; j < N; j++) {
////			if (proc_min_a[i] > proc_a[i * N + j]) {
////				proc_min_a[i] = proc_a[i * N + j];
////			}
////		}
////
////	}
////
////	for (int i = 0; i < proc_n / N; i++) {
////		if (proc_min_a[0] < proc_min_a[i]) {
////			proc_min_a[0] = proc_min_a[i];
////		}
////	}
////
////	//собираем обрабатываем
////	MPI_Reduce(proc_min_a, &maxmin, 1, MPI_INT, MPI_MAX, 0, MPI_COMM_WORLD);
////	//выводим
////	if (rank == 0) {
////		printf("MAXMIN: %d \n", maxmin);
////	}
////	MPI_Finalize();
////}
//
//void Task8()
//{
//	const int arrLength = 100;
//	int rank, commSize;
//	int count = 0, sum = 0;
//
//	MPI_Init(NULL, NULL);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &commSize);
//	printf("------------------------------------------\nLOG OF PROCESS %i\n", rank);
//	int partition = arrLength / commSize;
//	printf("Partition is %i\n", partition);
//
//	int* arr = new int[arrLength];
//	int* recBuf = (int*)malloc(partition * sizeof(int));
//	int* result = new int[arrLength];
//
//
//	//Раскидали на все потоки по части массива
//	if (rank == 0)
//	{
//
//		printf("Array:");
//		for (int i = 0; i < arrLength; i++)
//		{
//			arr[i] = i;
//			printf("%i ", arr[i]);
//		}
//		printf("\n");
//		for (int r = 0; r < commSize; r++)
//		{
//			int* sendBuf = (int*)malloc(partition * sizeof(int));
//			for (int p = 0; p < partition; p++)
//				sendBuf[p] = arr[p + r * partition];
//
//			if (r == 0)
//				recBuf = sendBuf;
//			else
//				MPI_Send(sendBuf, partition, MPI_INT, r, r + 10, MPI_COMM_WORLD);
//		}
//	}
//
//	//получаем на каждом потоке часть распила 
//	if (rank != 0)
//	{
//		MPI_Recv(recBuf, partition, MPI_INT, 0, rank + 10, MPI_COMM_WORLD, MPI_STATUSES_IGNORE);
//		printf("Received part\n");
//		for (int i = 0; i < partition; i++)
//		{
//			printf("%i ", recBuf[i]);
//		}
//		printf("\n");
//	}
//	
//	if (rank == 0)
//	{
//		for (int i = 0; i < partition; i++)
//			arr[i] = recBuf[i];
//	}
//	else
//	{
//		
//		MPI_Send(recBuf, partition, MPI_INT, 0, rank + 100, MPI_COMM_WORLD);
//
//		printf("self part send to 0 rnak\n");
//	}
//
//	if (rank == 0)
//	{
//		printf("\nFINAL PART OF 0 PROCESS\n\n");
//
//		for (int i = 1; i < commSize; i++)
//		{
//			MPI_Recv(recBuf, partition, MPI_INT, i, i + 100, MPI_COMM_WORLD, MPI_STATUSES_IGNORE);
//			printf("Reciving part from %i process\n", i);
//
//			for (int j = 0; j < partition; j++)
//			{
//				arr[partition * i + j] = recBuf[j];
//			}
//		}
//		printf("Final array:\n");
//		for (int i = 0; i < arrLength; i++)
//			printf("%i ", arr[i]);
//		printf("\n");
//	}
//	MPI_Barrier(MPI_COMM_WORLD);
//	printf("____________________________________________\n");
//	MPI_Finalize();
//
//
//}
//
//void Task9()
//{
//	MPI_Init(NULL, NULL);
//
//	int ProcRank, ProcNum, N = 17;
//	int* x = new int[N];
//	int* result = new int[N];
//
//	MPI_Comm_size(MPI_COMM_WORLD, &ProcNum);
//	MPI_Comm_rank(MPI_COMM_WORLD, &ProcRank);
//
//	//строим массив
//	if (ProcRank == 0) {
//		for (int i = 0; i < N; i++) {
//			x[i] = rand() % 100;
//			printf(" %d ", x[i]);
//		}
//		printf("\n");
//	}
//
//	int* len = new int[ProcNum];
//	int* ind = new int[ProcNum];
//	int* revind = new int[ProcNum];
//
//	int rest = N;
//	int k = rest / ProcNum;
//	len[0] = k;
//	ind[0] = 0;
//	revind[0] = N - k;
//
//	
//	for (int i = 1; i < ProcNum; i++) {
//		rest -= k;
//		k = rest / (ProcNum - i);
//		len[i] = k;
//		ind[i] = ind[i - 1] + len[i - 1];
//		revind[i] = revind[i - 1] - len[i];
//	}
//	int ProcLen = len[ProcRank];
//	int* subarr = new int[ProcLen];
//
//	//рассылаем письма
//	MPI_Scatterv(x, len, ind, MPI_INT, subarr, ProcLen, MPI_INT, 0, MPI_COMM_WORLD);
//
//	int* revers = new int[ProcLen];
//	for (int i = 0; i < ProcLen; i++) {
//		revers[i] = subarr[ProcLen - i - 1];
//	}
//	
//	MPI_Gatherv(revers, ProcLen, MPI_INT, result, len, revind, MPI_INT, 0, MPI_COMM_WORLD);
//
//	if (ProcRank == 0) {
//		printf("\n");
//		for (int i = 0; i < N; i++)
//			printf(" %d ", result[i]);
//	}
//
//	MPI_Finalize();
//}
//
//void fill_array(int* array, long int length)
//{
//	int seed = 0;
//	srand(clock() + seed);
//
//	for (int i = 0; i < length; i++)
//		array[i] = (rand() % 1000) - 500;
//}
//
//void Task10()
//{
//	int rank, size;
//	MPI_Init(NULL, NULL);
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//
//	const int arr_length = 120;
//	double start, end;
//
//	if (arr_length < size)
//	{
//		if (rank == 0) {
//			printf("Array length should be greater than number of threads. \n");
//		}
//		return;
//	}
//
//	int* arr = (int*)malloc(arr_length * sizeof(int));
//	int* rarr = (int*)malloc(arr_length * sizeof(int));
//	fill_array(arr, arr_length);
//
//	if (rank == 0)
//	{
//		start = MPI_Wtime();
//		MPI_Send(arr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD);
//		MPI_Recv(rarr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		end = MPI_Wtime();
//		printf("Send: time(%lf)\n", end - start);
//	}
//	else if (rank = 1)
//	{
//		MPI_Recv(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		MPI_Send(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD);
//	}
//
//	if (rank == 0)
//	{
//		start = MPI_Wtime();
//		//Посылка, которая использует синхронный (synchronous) режим
//		MPI_Ssend(arr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD);
//		MPI_Recv(rarr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		end = MPI_Wtime();
//		printf("Ssend: time(%lf)\n", end - start);
//	}
//	else if (rank = 1)
//	{
//		MPI_Recv(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		//Посылка, которая использует синхронный (synchronous) режим
//		MPI_Ssend(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD);
//	}
//
//	if (rank == 0)
//	{
//		start = MPI_Wtime();
//		//режим обмена по готовности (ready communication mode)
//		MPI_Rsend(arr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD);
//		MPI_Recv(rarr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		end = MPI_Wtime();
//		printf("Rsend: time(%lf)\n", end - start);
//	}
//	else if (rank = 1)
//	{
//		MPI_Recv(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		MPI_Rsend(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD);
//	}
//
//	int buf_veight = (MPI_BSEND_OVERHEAD + arr_length) * sizeof(int);
//	int* buf = (int*)malloc(buf_veight);
//	MPI_Buffer_attach(buf, buf_veight);
//
//	if (rank == 0)
//	{
//		start = MPI_Wtime();
//		//Буферизованный (buffered) режим операции посылки
//		MPI_Bsend(arr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD);
//		MPI_Recv(rarr, arr_length, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		end = MPI_Wtime();
//		printf("Bsend: time(%lf)\n", end - start);
//	}
//	else if (rank = 1)
//	{
//		MPI_Recv(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
//		MPI_Bsend(arr, arr_length, MPI_INT, 0, 0, MPI_COMM_WORLD);
//	}
//}
//
//int main(int argc, char** argv) {
//	//Task4();
//	//Task5();
//	//Task6();
//	//task7();
//	//Task8();
//	//Task9();
//	Task10();
//}