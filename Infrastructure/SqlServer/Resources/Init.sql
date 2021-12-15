use db_scrum_organisation_success;

if exists (select * from sysobjects where name='sos_user' and xtype='U')
    drop table sos_user;

if exists (select * from sysobjects where name='project' and xtype='U')
    drop table project;
    
if exists (select * from sysobjects where name='technology' and xtype='U')
    drop table technology;

if exists (select * from sysobjects where name='sprint' and xtype='U')
    drop table sprint;

if exists (select * from sysobjects where name='user_story' and xtype='U')
    drop table user_story;

if exists (select * from sysobjects where name='meeting' and xtype='U')
    drop table meeting;

if exists (select * from sysobjects where name='comment' and xtype='U')
    drop table comment;

if exists (select * from sysobjects where name='developer_project' and xtype='U')
    drop table developer_project;

if exists (select * from sysobjects where name='participation' and xtype='U')
    drop table participation;

if exists (select * from sysobjects where name='sprint_user_story' and xtype='U')
    drop table sprint_user_story;
    
if exists (select * from sysobjects where name='user_technology' and xtype='U')
    drop table user_technology;
    
if exists (select * from sysobjects where name='project_technology' and xtype='U')
    drop table project_technology;

/*roles :
  1 -> dev
  2 -> scrum master
  3 -> product owner*/
create table sos_user (
    id int identity primary key,
    firstname varchar(50) not null,
    lastname varchar(50) not null,
    password varchar(100) not null,
    email varchar(100) not null,
    profile_picture varchar(200) default '',
    role smallint not null,
    birthdate date not null,
    description varchar(500),
    portfolio varchar(100)
);

/*1 -> inactive
  2 -> active
  3 -> finished*/
create table project (
    id int identity primary key,
    id_product_owner int not null,
    id_scrum_master int not null,
    name varchar(100) not null,
    deadline date not null,
    description varchar(1000) not null,
    repository_url varchar(200) not null,
    sos_status smallint not null default 1
);

create table technology (
    id int identity primary key,
    name varchar(50) not null
);

create table sprint (
    id int identity primary key,
    id_project int not null,
    sprint_number int not null,
    start_date datetime not null,
    deadline datetime not null,
    description varchar(1000) not null
);

create table user_story (
    id int identity primary key,
    id_project int not null,
    name varchar(200) not null,
    description varchar(1000) not null,
    priority smallint not null
);

create table meeting (
    id int identity primary key,
    id_sprint int not null,
    schedule datetime not null,
    description varchar(1000) not null
);

create table comment (
    id int identity primary key,
    id_user_story int not null,
    id_user int not null,
    posted_at datetime not null,
    content varchar(1000) not null
);

create table developer_project (
    id_project int not null,
    id_developer int not null,
    is_appliance bit default 1
);

create table participation (
    id_meeting int not null,
    id_user int not null
);

create table sprint_user_story (
    id_sprint int not null,
    id_user_story int not null
);

create table user_technology (
    id_user int not null,
    id_technology int not null
);

create table project_technology (
    id_project int not null,
    id_technology int not null
);
