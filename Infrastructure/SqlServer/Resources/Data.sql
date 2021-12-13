/*Init users*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Florian', 'Mazzeo', 'scryper', 'florian.mazzeo@gmail.com', 1, convert(date, '20-12-2001', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Damien', 'Auversack', 'damien97', 'damsover@gmail.com', 2, convert(date, '23-07-1997', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Martin', 'Maes', 'dotni', 'martin.maes100.000@gmail.com', 3, convert(date, '26-11-1998', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Floran', 'Houdart', 'myneck', 'la199788@student.helha.be', 1, convert(date, '11-01-2001', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Mark', 'Zuckerberg', 'zuck', 'zuck@facebook.com', 3, convert(date, '14-05-1984', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Elon', 'Musk', 'tesla', 'elon.musk@tesla.com', 1, convert(date, '28-06-1971', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Patrick', 'Onatenpa', 'laref', 'onatenpa.patrick@camping.fr', 1, convert(date, '24-10-1994', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Vouza', 'Vaibien', 'choisi', 'techniquecellela@vandenborre.be', 2, convert(date, '14-08-2000', 103));

insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Lucas', 'Hauchard', 'squeezie', 'lucas.hauchard@squeezie.industries.fr', 2, convert(date, '27-01-1996', 103));

/*Init projects*/
insert into project(id_product_owner, id_scrum_master, name, deadline, description, repository_url, sos_status)
    values(3, 2, 'ScrumOrganisationSuccess API', convert(datetime, '24-12-2021 12:00:00', 103), 'Serveur pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessAPI', 2);

insert into project(id_product_owner, id_scrum_master, name, deadline, description, repository_url, sos_status)
    values(5, 8, 'ScrumOrganisationSuccess Web App', convert(datetime, '24-12-2021 12:00:00', 103), 'Site pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessWebApp', 2);

insert into project(id_product_owner, id_scrum_master, name, deadline, description, repository_url, sos_status)
    values(3, 9, 'Skydda', convert(datetime, '08-12-2021 12:00:00', 103), 'Jeu vidéo pour réussir son année',
    'https://github.com/Scryper/Skydda', 3);

insert into project(id_product_owner, id_scrum_master, name, deadline, description, repository_url)
    values(5, 9, 'Labo TCP/IP', convert(datetime, '08-12-2021 12:00:00', 103), 'Labo pour réussir son année',
    'https://github.com/Scryper/Labo01_TCP_IP');

/*Init technology*/
insert into technology(name)
    values('C#');

insert into technology(name)
    values('Python');

insert into technology(name)
    values('Java');

insert into technology(name)
    values('Angular');

insert into technology(name)
    values('Android');

insert into technology(name)
    values('.NET')

insert into technology(name)
    values('SFML')

insert into technology(name)
    values('C++')

insert into technology(name)
    values('C')

insert into technology(name)
    values('PHP')

insert into technology(name)
    values('Javascript')

/*Init sprints*/
insert into sprint(id_project, sprint_number, deadline, description, progression)
    values(1, 1, convert(date, '01-12-2021', 103), 'Création basique du serveur', 100);

/*Init user stories*/
insert into user_story(id_project, name, description, priority)
    values(1, 'User story pour réussir son année', 'On va réussir wola', 1);

/*Init meetings*/
insert into meeting(id_sprint, schedule, description)
    values(1, convert(datetime, '06-12-2021 12:00:00',131), 'Meeting pour réussir son année');

/*Init comments*/
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 1, convert(datetime, '26-11-2021 12:00:00', 131), 'Commentaire pour réussir son année');

/*Init project_user link table*/
insert into developer_project(id_project, id_developer)
    values(1, 1);

insert into developer_project(id_project, id_developer)
    values(1, 4);

/*Init participation link table*/
insert into participation(id_meeting, id_user)
    values(1, 1);

insert into participation(id_meeting, id_user)
    values(1, 2);

insert into participation(id_meeting, id_user)
    values(1, 3);

insert into participation(id_meeting, id_user)
    values(1, 4);

/*Init sprint user stories link table*/
insert into sprint_user_story(id_sprint, id_user_story)
    values(1, 1);

/*Init user technologies link table*/
insert into user_technology(id_user , id_technology)
    values(1, 1);

insert into user_technology(id_user , id_technology)
    values(1, 3);

insert into user_technology(id_user , id_technology)
    values(1, 4);

insert into user_technology(id_user , id_technology)
    values(1, 3);

insert into user_technology(id_user , id_technology)
    values(1, 5);

/*Init project technologies link table*/
insert into project_technology (id_project, id_technology)
    values(1, 1);