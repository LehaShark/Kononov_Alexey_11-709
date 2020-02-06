#include <stdio.h>
#include <stdlib.h> 

void reader(char ch, int num, FILE *file)
{
	int i=0;
	for(; i<num;)
	{
		ch = fgetc(file);
		if(ch == EOF) return;
		if(ch == '\n') i++;
		printf("%c", ch);		
	}
}

int main( int argc[] , char *argv[])
{
	FILE *file; 
	file = fopen(argv[1], "r");
	if(file==NULL)
	{
		printf("File doesn't exist. \n");
		return 1;
	}
	char ch;
	int num = atoi(argv[2]);	
	if (num == 0)	
	{	
		while ((ch = fgetc(file)) != EOF) 
			 printf("%c", ch);	
	}
	else
	{
		while(ch != EOF)
		{
			reader(ch, num, file);
			printf("\n Press Enter \n q for exit. \n");
			if (getchar() == 'q') break;
			else continue;			
		}	
	}	
	fclose(file);
	return 0;
}
