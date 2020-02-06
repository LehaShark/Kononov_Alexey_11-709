#include <stdio.h>
#include <sys/stat.h>

int main( int argc[] , char *argv[])
{
	struct stat stats;
	stat(argv[1], &stats);	

	FILE *first; 
	first = fopen(argv[1], "r");
	
	if(first==NULL)
	{
		printf("First file doesn't exist. \n");
		return 1;
	}
	FILE *second; 
	second = fopen(argv[2], "w");
	if(second==NULL)
	{
		printf("Second file doesn't exist. \n");
		return 1;
	}
	char ch;
	while((ch=fgetc(first)) !=EOF)
		fputc(ch, second);
 
	chmod(argv[1], stats.st_mode);
	
	fclose(first);
	fclose(second);
	return 0;
}
