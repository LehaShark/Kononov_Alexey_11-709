#include <stdio.h>
#include <sys/types.h>
#include <dirent.h>

void Jopa (DIR *dir){
	struct dirent * de;	
	while(de = readdir(dir))
		printf("%s \n", de->d_name);

}

void JopaIF (DIR *dir, char *argv[]){
	int n = 0;
	if((dir=opendir("."))==NULL && n == 0)
	{
		printf("Нет доступа. \n");
		return 1;
		n++;
	}
	
	if((dir=opendir(argv[1]))==NULL && n == 1)
	{
		printf("Нет доступа. \n");
		return 1;
	}
}

int main( int argc[] , char *argv[])
{
	DIR * dir;
	JopaIF(dir, argv[1]);
	/*
	if((dir=opendir("."))==NULL)
	{
		printf("Нет доступа. \n");
		return 1;
	}
	*/
	printf("Current: \n");
	Jopa(dir);
	
	JopaIF(dir);
	/*
	if((dir=opendir(argv[1]))==NULL)
	{
		printf("Нет доступа. \n");
		return 1;
	}
	*/
	printf("Choosen: \n");
	Jopa(dir);


	closedir(dir);
	return 0;
}
