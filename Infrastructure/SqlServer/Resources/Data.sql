/*Init users*/
insert into sos_user(pseudo, password, email, role, birthdate)
    values('Scryper', 'scryper', 'florian.mazzeo@gmail.com', 1, convert(date, '20-12-2001', 103));

insert into sos_user(pseudo, password, email, role, birthdate)
    values('Damsover', 'damien97', 'damsover@gmail.com', 2, convert(date, '23-07-1997', 103));

insert into sos_user(pseudo, password, email, role, birthdate)
    values('Dotni', 'dotni', 'martin.maes100.000@gmail.com', 3, convert(date, '26-11-1998', 103));

insert into sos_user(pseudo, password, email, role, birthdate)
    values('Myneck', 'myneck', 'la199788@student.helha.be', 1, convert(date, '11-01-2001', 103));

/*Init projects*/
insert into project(name, deadline, description, repository_url, id_product_owner, id_scrum_master)
    values('ScrumOrganisationSuccess', convert(datetime, '24-12-2021 12:00:00', 103), 'Serveur pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessAPI', 3, 2);

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

/*Init sprints*/
insert into sprint(sprint_number, id_project, deadline, description, progression)
    values(1, 1, convert(date, '01-12-2021', 103), 'Sprint pour réussir son année', 0);

/*Init user stories*/
insert into user_story(name, description, priority, id_project)
    values('User story pour réussir son année', 'On va réussir wola', 1, 1);

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