#include <stdio.h>
#include <sys/types.h>
#include <dirent.h>
#include <string.h>


void CompareTo(char *first, char *second)
{
    printf("Compare");
    FILE *fileF;
    fileF = fopen(first, "r");
    FILE *fileS;
    fileS = fopen(second, "r");
    char chf;
    char chs;
    while((chf=fgetc(fileF)) !=EOF || (chs=fgetc(fileS)) !=EOF)
    {
        if (chf != chs)
        {
            fclose(fileF);
            fclose(fileS);
            return;
        }
    }
    //printf("%s     %s \n", first, second);
    fclose(fileF);
    fclose(fileS);
}

void ExplorerS (char *first, char *second)
{
    //printf("lol");
    DIR * dir;
    struct dirent * de;
    if ( ( dir = opendir(second) ) == NULL )
    {
        //printf("Нет доступа. \n");
        return;
    }
    while ( de = readdir(dir) )
    {
        char third[100];
        snprintf(third, sizeof third, "%s%s%s", second, "/",de->d_name);
        if( de->d_name!=".." ||de->d_name!=".") continue;
        else if ( ( opendir(third ) != NULL ) )
            ExplorerS(first, third);
        else CompareTo(first, third);
    }
    closedir(dir);
}

void ExplorerF (char *first, char *second)
{
	DIR * dir;
    struct dirent * de;
	if ( ( dir = opendir(first) ) == NULL )
    {
		//printf("Нет доступа. \n %s", first);
		return;
	}
	while ( de = readdir(dir) )
    {
	    printf("%s \n", de->d_name);
        if( de->d_name==".." || de->d_name==".") continue;
        char *third[100];
        snprintf(third, sizeof third, "%s%s%s", first, "/", de->d_name);
        //printf("%s \n", third);
        if ( opendir(third) == NULL )
            ExplorerS(third, second);
		else ExplorerF(third, second);
	}
    closedir(dir);
}

int main()
{
    ExplorerF(argv[1], argv[2]);
    return 0;
}
