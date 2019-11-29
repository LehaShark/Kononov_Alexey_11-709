#include <stdio.h>
int main( int argc[] , char *argv[])
{
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
	fclose(first);
	fclose(second);
	return 0;
}
