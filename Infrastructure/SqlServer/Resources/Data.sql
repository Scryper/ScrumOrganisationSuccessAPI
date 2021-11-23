/*Init users*/
insert into sos_user(pseudo, password, email, role) 
    values('Scryper', 'scryper', 'florian.mazzeo@gmail.com', 1);

insert into sos_user(pseudo, password, email, role)
    values('Damsover', 'damien97', 'damsover@gmail.com', 2);

insert into sos_user(pseudo, password, email, role)
    values('Dotni', 'dotni', 'martin.maes100.000@gmail.com', 3);

insert into sos_user(pseudo, password, email, role)
    values('Myneck', 'myneck', 'la199788@student.helha.be', 1);

/*Init projects*/
insert into project(name, deadline, description, repository_url, id_product_owner, id_scrum_master) 
    values('ScrumOrganisationSuccess', convert(datetime, '24-12-2021 12:00:00', 103), 'Projet pour réussir son année', 
           'https://github.com/Scryper/ScrumOrganisationSuccess.git', 3, 2);

/*Init sprints*/
insert into sprint(sprint_number, id_project, deadline, description, progression)
    values(1, 1, convert(date, '01-12-2021', 103), 'Sprint pour réussir son année', 0);

/*Init user stories*/
insert into user_story(name, description, is_done, id_project)
    values('User story pour réussir son année', 'On va réussir wola', 0, 1);

/*Init meetings*/
insert into meeting(id_sprint, schedule, description)
    values(1, convert(datetime, '06-12-2021 12:00:00',131), 'Meeting pour réussir son année');

/*Init comments*/
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 1, convert(datetime, '26-11-2021 12:00:00', 131), 'Commentaire pour réussir son année');

/*Init project_user link table*/
insert into project_user(id_project, id_user)
    values(1, 1);

insert into project_user(id_project, id_user)
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