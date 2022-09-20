
create database services1

use services1

create table users
(
	id int identity(1,1),
	email varchar(300) not null,
	password varchar(500),
	primary key (email)
)

select * from users
delete users
drop table users

create table user_about
(
	id int not null,
	nic varchar(13) not null unique,
	fname varchar(100) not null,
	lname varchar(100) not null,
	dname varchar(100) not null,
	gender varchar(10) not null,
	bio varchar(500) not null,
	--interests int default 0,
	primary key(id)
)

select * from user_about
delete user_about
drop table user_about

create table user_contact
(
	id int not null,
	number varchar(11) not null,
	primary key (id,number)
)

select * from user_contact
delete user_contact
drop table user_contact

create table user_interest
(
	id int not null,
	interest varchar(50) not null,
	primary key (id,interest)
)

select * from user_interest
delete user_interest
drop table user_interest

create table user_location
(
	id int not null,
	address varchar(500) not null,
	province varchar(50) not null,
	district varchar(50) not null,
	town varchar(50) not null,
	latitude varchar(100) null,
	longtitude varchar(100) null,
	primary key (id)
)

select * from user_location
delete user_location
drop table user_location

create table user_education
(
	no int identity(1,1),
	id int not null,
	title varchar(100) not null,
	institute varchar(100) not null,
	deuration varchar(20) not null,
	primary key(no)
)

select * from user_education
delete user_education
drop table user_education

create table user_qualification
(
	no int identity(1,1),
	id int not null,
	title varchar(100) not null,
	place varchar(100) not null,
	details varchar(500) not null,
	primary key(no)
)

select * from user_qualification
delete user_qualification
drop table user_qualification

create table user_skills
(
	no int identity(1,1),
	id int not null,
	name varchar(100) not null,
	primary key(no)
)

select * from user_skills
delete user_skills
drop table user_skills

create table jobs
(
	id int identity(1,1),
	title varchar(100) not null,
	date varchar(50) not null,
	price float not null,
	bits int default 0,
	brief varchar(300) not null,
	info varchar(600) not null,
	key1 varchar(20) null,
	key2 varchar(20) null,
	key3 varchar(20) null,
	key4 varchar(20) null,
	primary key (id)
)

select * from jobs
drop table jobs

create table admins
(
	id int identity(1,1),
	email varchar(300) not null,
	password varchar(500),
	active int default 0,
	primary key (email)
)

select * from admins
delete admins
drop table admins

create table admin_data
(
	id int not null,
	name varchar(100) not null,
	nic varchar(13) not null unique,
	gender varchar(10) not null,
	address varchar(500) not null,
	contact1 varchar(11) not null,
	contact2 varchar(11) null,
	primary key (id)
)

select * from admin_data
delete admin_data
drop table admin_data

create table reports
(
	id int identity(1,1),
	title varchar(500) not null,
	message varchar(2000) not null,
	mark_read int default 0,
	read_admin int default 0,
	primary key(id)
)

select * from reports
delete reports
drop table reports

create table test
(
	id int,
	name varchar(100)
)

select * from test
delete test
drop table test

insert into test(id,name) values (1,'hello')