#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stddef.h>
#include <malloc.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <sys/wait.h>
#include <errno.h>
#include <dirent.h>
#include <libgen.h>
#include <unistd.h>
#include <fcntl.h>

#define BUFFER 64*1024*1024

char *script_name = NULL;
int MAX_PROCESSES = 0;
int status = 0;
int process_count = 0;

void print_error(const int pid, const char *scr_name, const char *msg_err, const char *f_name) 
{
    fprintf(stderr, "%d %s: %s %s\n", pid, scr_name, msg_err, (f_name)? f_name : NULL);
}

void print_result(const char *dir, int bytes_count)
{
    printf("%d %s %d\n", getpid(), dir, bytes_count);
}

void copy_files(const char *current_dir1, const char *current_dir2, int *bytes_count) 
{
    mode_t mode;// права доступа к файлу
    struct stat file_information;//статус
    if (access(current_dir1, R_OK) == -1) {//проверяем права доступа
    	print_error(getpid(), script_name,   strerror(errno), current_dir1);
    	return;
    }
    if ((stat(current_dir1, &file_information) == -1)) {//проверяем помещаем в структуру, если не смогли записать
    	print_error(getpid(), script_name, strerror(errno), current_dir1);
    	return;
    }

    mode = file_information.st_mode & (S_IRWXU|S_IRWXG|S_IRWXO);//записываем права доступа

    int file_source = open(current_dir1, O_RDONLY); 
    int file_destination = open(current_dir2, O_WRONLY|O_CREAT, mode); 

    *bytes_count = 0;
    char *buff;
    buff = (char *) malloc(BUFFER);

    ssize_t read_val, write_val;
//берем из 1 директории файл
    while (((read_val = read(file_source, buff, BUFFER)) != 0) && (read_val != -1)) {

        // записываем во вторую
    	if ((write_val = write(file_destination, buff, (size_t)read_val)) == -1) {
    	    print_error(getpid(), script_name,   "Ошибка записи в файл.", current_dir2);
	
	    close(file_source);
	    close(file_destination);
    	    free(buff);
    	    return;
    	}

        // подсчитываем байты
    	*bytes_count += write_val;
    }
    //пытаемся закрыть.
    close(file_source);
    close(file_destination);
}

void process_directory(char *dir1, char *dir2) 
{
	DIR *copied_dir = opendir(dir1);
	if (!copied_dir) {
    	print_error(getpid(), script_name, strerror(errno), dir1);
    	return;
	}

    char *current_dir1 = alloca(strlen(dir1) + NAME_MAX + 3);//выделяем память
    current_dir1[0] = 0; 
    strcat(strcat(current_dir1, dir1), "/");//записываем путь
    size_t current_len1 = strlen(current_dir1);//размер

    char *current_dir2 = alloca(strlen(dir2) + NAME_MAX + 3);
    current_dir2[0] = 0;
    strcat(strcat(current_dir2, dir2), "/");
    size_t current_len2 = strlen(current_dir2);

    struct dirent *selected_dir;
    struct stat buf1, buf2;
    errno = 0;

    while ( (selected_dir = readdir(copied_dir) ) != NULL ) {//пока есть что читать
        current_dir1[current_len1] = 0;
        strcat(current_dir1, selected_dir->d_name);//добавляем название файла в путь
	    current_dir2[current_len2] = 0;
        strcat(current_dir2, selected_dir->d_name);

        if ((lstat(current_dir1, &buf1) == -1)) {//проверяем статус (buf1) доступ
    	    print_error(getpid(), script_name, strerror(errno), current_dir1);
    	    continue;       
	    }
        // если директория
        if ( S_ISDIR(buf1.st_mode) ) {  
	
            if ( (strcmp(selected_dir->d_name, ".") != 0) && (strcmp(selected_dir->d_name, "..") != 0) )  {//если не пусто взываем рекурсивно и идем дальше по каталогу, иначе не остановимся.
		printf("JOPA\n");
                if (stat(current_dir2, &buf2) != 0) {
                    mkdir(current_dir2, buf1.st_mode);//создаем новую директорию
    		    }
    		    process_directory(current_dir1, current_dir2);
            }
        }//если файл
        else 
if ( S_ISREG(buf1.st_mode) ) 
{
                if (process_count > MAX_PROCESSES) {//останавливаем если
                    int status;

                    if (wait(&status) != 0) {//родительский процесс.
			//printf("proc_JOPA === %d \n", getpid());
                        --process_count;
                    }
}

        		if (stat(current_dir2, &buf2) != 0) {//при успешном заполнении = 0 если нет файла то создаем процесс и в нем копируем (последний else сюда)

        		    pid_t pid = fork();

                    if (pid == 0) { //дочерний
                        int bytes_count = 0;
                        copy_files(current_dir1, current_dir2, &bytes_count);
// копируем и пишем
            			if (bytes_count != 0) {
                            print_result(current_dir1, bytes_count);   
            			}
            			exit(EXIT_SUCCESS); 
                    } 
                    process_count++;   
        		} 
		else //значит файл существует
        		    print_error(getpid(), script_name,  "существует, sosi", current_dir2);
            }   
           
    }  
closedir(copied_dir);
    
}

int main(int argc, char *argv[]) 
{
	//printf("=======================================%d \n", getpid());
	script_name = basename(argv[0]);

        char *dir1 = realpath(argv[1], NULL); 
	char *dir2 = realpath(argv[2], NULL);

	if (dir1 == NULL) {
    	print_error(getpid(), script_name, "Ошибка открытия каталога.", argv[1]);
    	return 1;
	} 
	if (dir2 == NULL) {
		print_error(getpid(), script_name,  "Ошибка открытия каталога.", argv[2]);
		return 1;
	}

	MAX_PROCESSES = atoi(argv[3]);

	if (MAX_PROCESSES <= 0) {
    	print_error(getpid(), script_name, "Недопустимое значение MAX_PROCESSES ", NULL);
    	return EXIT_FAILURE;
	}

	process_directory(dir1, dir2);

	while (wait(NULL) > 0) 
    { 
    }
	return EXIT_SUCCESS;
}
