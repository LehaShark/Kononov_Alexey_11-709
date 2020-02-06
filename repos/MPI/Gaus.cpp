#include<iostream>
#include"mpi.h"
#include <time.h>

using namespace std;

int get_chunk(int total, int ProcNum, int ProcRank) {//разделяем на ленты
	int n = total; //сколько строк в матрице
	int q = n / ProcNum;
	if (n % ProcNum)
		q++; // вычисляем сколько раздать процессам
	int r = ProcNum * q - n; //cколько лишних если раздать

	int chunk = q;
	if (ProcRank >= ProcNum - r)
		chunk = q - 1;

	return chunk;
}

int main(int argc, char* argv[]) {
	int n = 15;
	int ProcRank, ProcNum;
	MPI_Init(&argc, &argv);

	MPI_Comm_size(MPI_COMM_WORLD, &ProcNum);
	MPI_Comm_rank(MPI_COMM_WORLD, &ProcRank);

	int nrows = get_chunk(n, ProcNum, ProcRank); //количество строк для каждого процесса, разделение матрицы на ленты

	//выделение памяти под массивы
	int* rows = (int*)malloc(sizeof(*rows) * nrows);
	double* a = (double*)malloc(sizeof(*a) * nrows * (n + 1));
	double* x = (double*)malloc(sizeof(*x) * n);
	double* tmp = (double*)malloc(sizeof(*tmp) * (n + 1));

	//инициализация
	for (int i = 0; i < nrows; i++) {
		rows[i] = ProcRank + ProcNum * i;
		srand(rows[i] * (n + 1));
		for (int j = 0; j < n; j++)
			a[i * (n + 1) + j] = rand() % 100 + 1;
		//b[i]
		a[i * (n + 1) + n] = rand() % 100 + 1;
	}

	if (ProcRank == 0) {
		//printf("Proc %d:", ProcRank);
		for (int i = 0; i < nrows; i++)
			printf("%d \n ", rows[i]);
		//printf("\n");
	}

	//прямой ход
	int row = 0;
	for (int i = 0; i < n - 1; i++) {
		//исключаем x_i вбираем определенную строку относительно которой будем делать вычисления
		//if (i == rows[row]) {
		//рассылаем строку i
		MPI_Bcast(&a[row * (n + 1)], n + 1, MPI_DOUBLE, ProcRank, MPI_COMM_WORLD);
		for (int j = 0; j <= n; j++)
			tmp[j] = a[row * (n + 1) + j];//записываем строку в каждый процесс
		row++;
		//}

		//вычитаем принятую строку из уравнений в текущем процессе
		for (int j = row; j < nrows; j++) {
			double scaling = a[j * (n + 1) + i] / tmp[i];
			for (int k = i; k < n + 1; k++)
				a[j * (n + 1) + k] -= scaling * tmp[k];
		}
	}

	//инициализация неизвестных
	row = 0;
	for (int i = 0; i < n; i++) {
		x[i] = 0;
		if (i == rows[row]) {
			x[i] = a[row * (n + 1) + n];
			row++;
		}
	}

	//обратный ход
	row = nrows - 1;
	for (int i = n - 1; i > 0; i--) {
		if (row >= 0) {
			x[i] /= a[row * (n + 1) + i]; //передаем найденное x_i подсчитываем количество нерешенных строк
			MPI_Bcast(&x[i], 1, MPI_DOUBLE, ProcRank, MPI_COMM_WORLD);//отправляем данные о переменной
			row--;
		}
		else {
			MPI_Bcast(&x[i], 1, MPI_DOUBLE, i % ProcNum, MPI_COMM_WORLD);
		}
		for (int j = 0; j <= row; j++) { //корректировка локальных x_i то, что разослали которые были отправлены в bcast
			x[rows[j]] -= a[j * (n + 1) + i] * x[i];
		}
	}

	if (ProcRank == 0) {
		x[0] /= a[row * (n + 1)]; //корректировка x_0
	}
	MPI_Bcast(x, 1, MPI_DOUBLE, 0, MPI_COMM_WORLD); //все процессы содержать корректный вектор x[n]

	free(tmp);
	free(rows);
	free(a);

	if (ProcRank == 0) {
		printf("Method Gausa\n");
		printf("MPI x[%d]: ", n);
		for (int i = 0; i < n; i++) {
			printf("%f ", x[i]);
		}
		printf("\n");
	}

	free(x);
	MPI_Finalize();
	return 0;
}