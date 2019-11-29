#include <stdio.h>
int main( int argc[] , char *argv[])
{
	FILE *file; 
	char i;
	
	file = fopen(argv[1], "w");
	if(file==NULL)
	{
		printf("File doesn't exist. \n");
		return 1;
	}
	
	while ((i = getchar()) != 27)
	{
		fputc(i, file);
	}	
	fclose(file);
	return 0;
}
