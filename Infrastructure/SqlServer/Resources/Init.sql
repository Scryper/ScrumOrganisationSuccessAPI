use db_scrum_organisation_success;

if exists (select * from sysobjects where name='project_user' and xtype='U')
    drop table project_user;

if exists (select * from sysobjects where name='user_project' and xtype='U')
    drop table user_project;

if exists (select * from sysobjects where name='sprint_user_story' and xtype='U')
    drop table sprint_user_story;

if exists (select * from sysobjects where name='user_technology' and xtype='U')
    drop table user_technology;

if exists (select * from sysobjects where name='project_technology' and xtype='U')
    drop table project_technology;

if exists (select * from sysobjects where name='participation' and xtype='U')
    drop table participation;

if exists (select * from sysobjects where name='meeting' and xtype='U')
    drop table meeting;

if exists (select * from sysobjects where name='sprint' and xtype='U')
    drop table sprint;

if exists (select * from sysobjects where name='comment' and xtype='U')
    drop table comment;

if exists (select * from sysobjects where name='user_story' and xtype='U')
    drop table user_story;

if exists (select * from sysobjects where name='project' and xtype='U')
    drop table project;

if exists (select * from sysobjects where name='sos_user' and xtype='U')
    drop table sos_user;

if exists (select * from sysobjects where name='technology' and xtype='U')
    drop table technology;

/*roles :
  1 -> dev
  2 -> scrum master
  3 -> product owner*/
create table sos_user(
    id int identity primary key,
    firstname varchar(50) not null,
    lastname varchar(50) not null,
    password varchar(100) not null,
    email varchar(100) not null,
    profile_picture varchar(200) default './assets/images/profilePictures/anonym.jpg',
    role smallint not null,
    birthdate date not null,
    description varchar(500),
    portfolio varchar(100)
);

/*1 -> inactive
  2 -> active
  3 -> finished*/
create table project(
    id int identity primary key,
    name varchar(100) not null,
    deadline date not null,
    description varchar(1000) not null,
    repository_url varchar(200) not null,
    sos_status smallint not null default 1,
);

create table technology (
    id int identity primary key,
    name varchar(50) not null
);

create table user_project (
    id_project int not null,
    id_user int not null,
    is_appliance bit default 1,
    primary key(id_project, id_user),
    foreign key(id_project) references project(id) on delete cascade,
    foreign key(id_user) references sos_user(id) on delete cascade
);

create table user_technology (
    id_user int not null,
    id_technology int not null,
    PRIMARY KEY(id_user,id_technology),
    FOREIGN KEY (id_user) REFERENCES sos_user(id) on delete cascade,
    FOREIGN KEY (id_technology) REFERENCES technology(id) on delete cascade
);

create table project_technology (
    id_project int not null,
    id_technology int not null,
    PRIMARY KEY(id_project,id_technology),
    FOREIGN KEY (id_project) REFERENCES project(id) on delete cascade,
    FOREIGN KEY (id_technology) REFERENCES technology(id) on delete cascade                     
);

create table sprint (
    id int identity primary key,
    id_project int not null,
    sprint_number int not null,
    start_date datetime not null,
    deadline datetime not null,
    description varchar(1000) not null,
    foreign key(id_project) references project(id) ON UPDATE CASCADE
);

create table user_story (
    id int identity primary key,
    id_project int not null,
    name varchar(200) not null,
    description varchar(1000) not null,
    priority smallint not null,
    foreign key(id_project) references project(id) ON UPDATE CASCADE
);

create table sprint_user_story (
   id_sprint int not null,
   id_user_story int not null,
   primary key(id_sprint, id_user_story),
   foreign key(id_sprint) references sprint(id) on delete cascade,
   foreign key(id_user_story) references user_story(id) on delete cascade
);

create table comment (
     id int identity primary key,
     id_user_story int not null,
     id_user int not null,
     posted_at datetime not null,
     content varchar(1000) not null,
     foreign key(id_user_story) references user_story(id) ON UPDATE CASCADE ON DELETE CASCADE,
     foreign key(id_user) references sos_user(id) ON UPDATE CASCADE ON DELETE CASCADE
);

create table meeting (
     id int identity primary key,
     id_sprint int not null,
     schedule datetime not null,
     description varchar(1000) not null,
     meeting_url varchar(300) not null,
     foreign key(id_sprint) references sprint(id) ON UPDATE CASCADE ON DELETE CASCADE
);

create table participation (
   id_meeting int not null,
   id_user int not null,
   PRIMARY KEY(id_user,id_meeting),
   FOREIGN KEY (id_user) REFERENCES sos_user(id) on delete cascade,
   FOREIGN KEY (id_meeting) REFERENCES meeting(id) on delete cascade
);

