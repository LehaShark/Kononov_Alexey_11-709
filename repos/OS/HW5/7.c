#include "stdio.h"
#include "stdlib.h"
#include "dirent.h"
#include <string.h>
#include <sys/stat.h>
#include <limits.h>
#include <time.h>
#include <libgen.h>

char* fname = NULL;
void GetDir(char* dir);
void PrintInfo(char* path);
char* filename, * progname;
int num_file = 0, num_dir = 1;

int main(int argc, char* argv[]) {//1 параметр - путь к папке которую ищем 2 название файла
    filename = argv[2];
    fname = argv[2];// название файла
    progname = basename(argv[0]);//название программы
    GetDir(argv[1]);//с названием пути в папке
    printf("Directories checked: %d\n", num_dir);
    printf("Files checked: %d\n", num_file);
    return 0;
}
void GetDir(char* dir) {
    struct dirent* d;// dirent, которые содержат данные о файлах в директории
    DIR* dp;// Команда DIR позволяет отобразить список файлов и подкаталогов для указанного каталога. Список может быть отсортирован по множеству критериев, задаваемых параметрами командной строки.
    if ((dp = opendir(dir)) == NULL)//открываем директорию
    {
        fprintf(stderr, "%s: Couldn't open %s.\n", progname, dir);//пишем, что не можем 
        return;
    }
    while ((d = readdir(dp)) != NULL) {//читаем с этой директории
        char path[1024];
        char buf[200];
        if (d->d_type == DT_DIR) {//d_type тип объекта dt_dir - обозначим что каталог. Если каталог то
            if (strcmp(d->d_name, ".") == 0 || strcmp(d->d_name, "..") == 0)// возвращает 0 если сравнение верное . .. - когда нет файлов
                continue;
            if (strcmp(dir, "/") == 0) { // если путь = /
                snprintf(path, sizeof(path), "/%s", d->d_name);// Запись форматированной строки в строку с ограничением по размеру строки. Добавляет путь директории 
                //когда в дире нет файла пропускаем, а когда есть внутри дирктория, то мы дописываем название директории и вызываем рекурсивно.
            }
            else {
                snprintf(path, sizeof(path), "%s/%s", dir, d->d_name);// пишем путь к файлу. 
            }
            num_dir++;
            GetDir(path);// вызываем рекурсивно
        }
        else {
            num_file++;
            if (strcmp(d->d_name, filename) == 0) {// сравниваем название с нашим файлом. 
                snprintf(path, sizeof(path), "%s/%s", dir, d->d_name);//Если одинаковые то сохраняем путь и передаем в принт инфо
                PrintInfo(path);
            }
        }
    }
    closedir(dp);
}

void PrintInfo(char* path) {
    FILE* fp;
    struct stat buff;
    stat(path, &buff);
    printf("File path  %s \n", path);
    printf("File name  %s \n", fname);
    printf("Size %ld \n", buff.st_size);
    printf("Create date %s", asctime(gmtime(&buff.st_ctime)));
    printf("Prava dostupa %3o\n", buff.st_mode);
}
