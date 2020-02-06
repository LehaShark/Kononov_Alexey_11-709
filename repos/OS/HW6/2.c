#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void time4fork(){
/*
	time_t time(time_t *tp);
	time_t mktime(struct tm *tp);
	char *asctime(const struct tm *tp);
	printf(*asctime);
*/
	struct timespec ms;
	clock_gettime (CLOCK_REALTIME, &ms);
	
	time_t t = time(NULL);
  	struct tm* tme = localtime(&t);
  	printf("%02d:%02d:%02d:%02d \n\n",tme->tm_hour, tme->tm_min, tme->tm_sec, ms.tv_nsec/1000000);

}

void fork2child(){
	
	pid_t jopa = fork();
	
	if(!jopa){
		printf("jopa1 = %d\n", getpid());
		printf("jopa1parent = %d\n", getppid());
		time4fork();
	}
	
	else{
		printf("parent = %d\n", getpid());
		//printf("parent's parent = %d\n", getppid());
		time4fork();
	}
	
	if(!fork() && !jopa){
		printf("jopa2 = %d\n", getpid());
		printf("jopa2parent = %d\n", getppid());
		time4fork();
	}
}

int main(
//int argc, int **argv
){
	int parent = getpid();
	fork2child();
	if(getpid() == parent)
		system("ps -x");
	return 0;
}
