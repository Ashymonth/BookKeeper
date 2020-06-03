﻿CREATE DATABASE {0} ON PRIMARY 
    (NAME = {1},
    FILENAME = '{2}',
    SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)
    LOG ON (NAME = {3}_Log,
    FILENAME = '{4}.ldf',
    SIZE = 1MB, 
    MAXSIZE = 5MB, 
    FILEGROWTH = 10%)