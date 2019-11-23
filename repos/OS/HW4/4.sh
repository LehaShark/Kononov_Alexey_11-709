#!/bin/bash

# $@ - all arc passed
for arg in $@
do
    echo $arg
    echo $arg >> temp.txt
done

exit 0

# Написать скрипт, выводящий на консоль и в файл все аргументы командной строки.
