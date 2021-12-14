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
    values('.NET');

insert into technology(name)
    values('SFML');

insert into technology(name)
    values('C++');

insert into technology(name)
    values('C');

insert into technology(name)
    values('PHP');

insert into technology(name)
    values('Javascript');
    
insert into technology(name)
    values('Typescript');
    
insert into technology(name)
    values('HTML');

/*Init sprints*/
insert into sprint(id_project, sprint_number, deadline, description)
    values(1, 1, convert(date, '01-12-2021', 103), 'Création basique du serveur');
   
insert into sprint(id_project, sprint_number, deadline, description)
    values(1, 2, convert(date, '15-12-2021', 103), 'Ajout des dernières fonctionnalités nécessaires');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(2, 1, convert(date, '06-12-2021', 103), 'Premier jet des pages du site');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(2, 2, convert(date, '20-12-2021', 103), 'Deuxième jet des pages du site');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(3, 1, convert(date, '10-10-2021', 103), 'Ajout des premiers mouvements');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(3, 2, convert(date, '10-11-2021', 103), 'Ajout des personnages et maps');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(3, 3, convert(date, '06-12-2021', 103), 'Finitions, améliorations, factorisation');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(4, 1, convert(date, '10-11-2021', 103), 'Création du visuel des pages');
    
insert into sprint(id_project, sprint_number, deadline, description)
    values(4, 2, convert(date, '24-11-2021', 103), 'Création du back-end des pages');

/*Init user stories*/
insert into user_story(id_project, name, description, priority)
    values(1, 'User story pour réussir son année.', 'On va réussir wola.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(1, 'Encore une user story.', 'On va réussir vraiment.', 2);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En  tant que visiteur, je peux m\'inscrire.', 'Un visiteur sur le site peut s\'inscrire si son adresse mail n\'est pas déjà présente dans la base de donnée.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En tant qu\'utilisateur inscrit, je peux me connecter.', 'L\'utilisateur qui s\'est inscrit peut se connecter à son compte.', 2);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En tant qu\'utilisateur, je peux consulter ma liste de meetings prévus.', 'L\'utilisateur de n\'importe quel type, peut consulter un calendrier contenant tout les meetings auquel il est convié.', 3);

insert into user_story(id_project, name, description, priority)
    values(2, 'En tant que scrum master, je peux ajouter des meetings.', 'Le scrum master peut créer des meetings auquel il convie les développeurs et/ou le product owner.', 4);

insert into user_story(id_project, name, description, priority)
    values(3, 'En tant que joueur, je peux sauter.', 'Le joueur peut sauter grâce aux touches affectées.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(3, 'En tant que joueur, je peux attaquer mon adversaire.', 'Le joueur peut ataquer l\'adversaire et lui faire subir des dégâts grâce aux touches affectées.', 2);
    
insert into user_story(id_project, name, description, priority)
    values(3, 'En tant qu\'utilisateur, je peux modifier le voolume de la musique de fond.', 'L\'utilisateur peut modifier le volume de la musique de fond. La valeur varie entre 0 et 100.', 3);

insert into user_story(id_project, name, description, priority)
    values(4, 'En tant qu\'utilisateur je peux naviguer sur le site.', 'L\'utilisateur peut choisir sur quel page il veut aller.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(4, 'En tant qu\'utilisateur je peux revenir sur la page d\'acceuil.', 'L\'utilisateur peut revenir sur la page d\'accueil, et ce depuis n\'importe quel autre page du site.', 2);

/*Init meetings*/
insert into meeting(id_sprint, schedule, description)
    values(1, convert(datetime, '06-12-2021 12:00:00', 131), 'Meeting pour réussir son année.');
    
insert into meeting(id_sprint, schedule, description)
    values(1, convert(datetime, '15-12-2021 12:00:00', 131), 'Mise en commun des branches.');
    
insert into meeting(id_sprint, schedule, description)
    values(1, convert(datetime, '16-12-2021 12:00:00', 131), 'Partage des tâches restantes.');
    
insert into meeting(id_sprint, schedule, description)
    values(2, convert(datetime, '14-12-2021 12:00:00', 131), 'Mise en commun des branches.');
    
insert into meeting(id_sprint, schedule, description)
    values(2, convert(datetime, '14-12-2021 15:00:00', 131), 'Partage des tâches restantes.');
    
insert into meeting(id_sprint, schedule, description)
    values(3, convert(datetime, '14-11-2021 15:00:00', 131), 'Mise en commun des branches.');
    
insert into meeting(id_sprint, schedule, description)
    values(3, convert(datetime, '01-12-2021 15:00:00', 131), 'Partage des tâches restantes.');
    
insert into meeting(id_sprint, schedule, description)
    values(3, convert(datetime, '07-12-2021 15:00:00', 131), 'Organisation de la présentation orale.');
    
insert into meeting(id_sprint, schedule, description)
    values(4, convert(datetime, '10-10-2021 15:00:00', 131), 'Partage des tâches.');
    
insert into meeting(id_sprint, schedule, description)
    values(4, convert(datetime, '20-10-2021 15:00:00', 131), 'Mise en commun des branches.');

/*Init comments*/
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 1, convert(datetime, '26-11-2021 12:00:00', 131), 'Commentaire pour réussir son année.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 2, convert(datetime, '26-11-2021 12:30:00', 131), 'Tu as raison.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 6, convert(datetime, '26-11-2021 12:30:00', 131), 'Tu es embauché.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 6, convert(datetime, '02-12-2021 12:30:00', 131), 'Eeeeh vous me copiez la.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 2, convert(datetime, '02-12-2021 13:30:00', 131), 'Mais pas du tout ????!!!! C\'est quand même normal de pouvoir s\'inscrire sur un site!!!');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 3, convert(datetime, '03-12-2021 13:34:00', 131), 'De fou détends toi le zuck.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 3, convert(datetime, '10-10-2021 13:34:00', 131), 'Le bateeeauuu naviiiigueeeee.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 1, convert(datetime, '10-10-2021 13:35:00', 131), 'T\'es ravagé toi.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 8, convert(datetime, '10-12-2021 13:35:00', 131), 'Je veux voir vos têtes vous dateeeeeez!');

insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 9, convert(datetime, '10-12-2021 13:35:00', 131), 'Oh non pas lui....');

/*Init project_user link table*/
insert into developer_project(id_project, id_developer)
    values(1, 1);

insert into developer_project(id_project, id_developer)
    values(1, 4);
    
insert into developer_project(id_project, id_developer)
    values(4, 1);
    
insert into developer_project(id_project, id_developer)
    values(1, 7);
    
insert into developer_project(id_project, id_developer)
    values(4, 7);
    
insert into developer_project(id_project, id_developer)
    values(1, 6);
    
insert into developer_project(id_project, id_developer)
    values(4, 6);

/*Init participation link table*/
insert into participation(id_meeting, id_user)
    values(1, 1);

insert into participation(id_meeting, id_user)
    values(1, 2);

insert into participation(id_meeting, id_user)
    values(1, 3);

insert into participation(id_meeting, id_user)
    values(1, 4);
    
insert into participation(id_meeting, id_user)
    values(2, 1);

insert into participation(id_meeting, id_user)
    values(2, 2);

insert into participation(id_meeting, id_user)
    values(2, 3);

insert into participation(id_meeting, id_user)
    values(2, 4);
    
insert into participation(id_meeting, id_user)
    values(3, 1);

insert into participation(id_meeting, id_user)
    values(3, 2);

insert into participation(id_meeting, id_user)
    values(3, 3);

insert into participation(id_meeting, id_user)
    values(3, 4);
    
insert into participation(id_meeting, id_user)
    values(4, 1);

insert into participation(id_meeting, id_user)
    values(4, 2);

insert into participation(id_meeting, id_user)
    values(4, 3);

insert into participation(id_meeting, id_user)
    values(4, 4);
    
insert into participation(id_meeting, id_user)
    values(5, 1);

insert into participation(id_meeting, id_user)
    values(5, 2);

insert into participation(id_meeting, id_user)
    values(5, 3);

insert into participation(id_meeting, id_user)
    values(5, 4);

/*Init sprint user stories link table*/
insert into sprint_user_story(id_sprint, id_user_story)
    values(1, 1);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(2, 2);

/*Init user technologies link table*/
insert into user_technology(id_user, id_technology)
    values(1, 1);
    
insert into user_technology(id_user, id_technology)
    values(1, 2);

insert into user_technology(id_user, id_technology)
    values(1, 3);

insert into user_technology(id_user, id_technology)
    values(1, 4);

insert into user_technology(id_user, id_technology)
    values(1, 5);
    
insert into user_technology(id_user, id_technology)
    values(1, 6);
    
insert into user_technology(id_user, id_technology)
    values(1, 7);
    
insert into user_technology(id_user, id_technology)
    values(1, 8);
    
insert into user_technology(id_user, id_technology)
    values(1, 9);
    
insert into user_technology(id_user, id_technology)
    values(1, 10);
    
insert into user_technology(id_user, id_technology)
    values(1, 11);
    
insert into user_technology(id_user, id_technology)
    values(1, 12);
    
insert into user_technology(id_user, id_technology)
    values(1, 13);
    
insert into user_technology(id_user,  id_technology)
    values(2, 1);
    
insert into user_technology(id_user, id_technology)
    values(2, 2);
    
insert into user_technology(id_user, id_technology)
    values(2, 3);

insert into user_technology(id_user, id_technology)
    values(2, 4);

insert into user_technology(id_user, id_technology)
    values(2, 5);
    
insert into user_technology(id_user, id_technology)
    values(2, 6);
    
insert into user_technology(id_user, id_technology)
    values(2, 7);
    
insert into user_technology(id_user, id_technology)
    values(2, 8);
    
insert into user_technology(id_user, id_technology)
    values(2, 9);
    
insert into user_technology(id_user, id_technology)
    values(2, 10);
    
insert into user_technology(id_user, id_technology)
    values(2, 11);
    
insert into user_technology(id_user, id_technology)
    values(2, 12);
    
insert into user_technology(id_user, id_technology)
    values(2, 13);
    
insert into user_technology(id_user, id_technology)
    values(3, 1);
    
insert into user_technology(id_user, id_technology)
    values(3, 2);

insert into user_technology(id_user, id_technology)
    values(3, 3);

insert into user_technology(id_user, id_technology)
    values(3, 4);

insert into user_technology(id_user, id_technology)
    values(3, 5);
    
insert into user_technology(id_user, id_technology)
    values(3, 6);
    
insert into user_technology(id_user, id_technology)
    values(3, 7);
    
insert into user_technology(id_user, id_technology)
    values(3, 8);
    
insert into user_technology(id_user, id_technology)
    values(3, 9);
    
insert into user_technology(id_user, id_technology)
    values(3, 10);
    
insert into user_technology(id_user, id_technology)
    values(3, 11);
    
insert into user_technology(id_user, id_technology)
    values(3, 12);
    
insert into user_technology(id_user, id_technology)
    values(3, 13);
    
insert into user_technology(id_user, id_technology)
    values(4, 1);
    
insert into user_technology(id_user, id_technology)
    values(4, 2);

insert into user_technology(id_user, id_technology)
    values(4, 3);

insert into user_technology(id_user, id_technology)
    values(4, 4);

insert into user_technology(id_user, id_technology)
    values(4, 5);
    
insert into user_technology(id_user, id_technology)
    values(4, 6);
    
insert into user_technology(id_user, id_technology)
    values(4, 7);
    
insert into user_technology(id_user, id_technology)
    values(4, 8);
    
insert into user_technology(id_user, id_technology)
    values(4, 9);
    
insert into user_technology(id_user, id_technology)
    values(4, 10);
    
insert into user_technology(id_user, id_technology)
    values(4, 11);
    
insert into user_technology(id_user, id_technology)
    values(4, 12);
    
insert into user_technology(id_user, id_technology)
    values(4, 13);
    
insert into user_technology(id_user, id_technology)
    values(5, 4);
    
insert into user_technology(id_user, id_technology)
    values(5, 6);
    
insert into user_technology(id_user, id_technology)
    values(6, 1);

insert into user_technology(id_user, id_technology)
    values(6, 11);
    
insert into user_technology(id_user, id_technology)
    values(6, 13);
    
insert into user_technology(id_user, id_technology)
    values(7, 1);

insert into user_technology(id_user, id_technology)
    values(7, 11);
    
insert into user_technology(id_user, id_technology)
    values(7, 13);
    
insert into user_technology(id_user, id_technology)
    values(8, 1);
    
insert into user_technology(id_user, id_technology)
    values(8, 6);
    
insert into user_technology(id_user, id_technology)
    values(9, 7);
    
insert into user_technology(id_user, id_technology)
    values(9, 8);
    
insert into user_technology(id_user, id_technology)
    values(9, 11);
    
insert into user_technology(id_user, id_technology)
    values(9, 13);

/*Init project technologies link table*/
insert into project_technology (id_project, id_technology)
    values(1, 1);
    
insert into project_technology (id_project, id_technology)
    values(1, 6);
    
insert into project_technology (id_project, id_technology)
    values(2, 4);
    
insert into project_technology (id_project, id_technology)
    values(2, 12);
    
insert into project_technology (id_project, id_technology)
    values(3, 7);
    
insert into project_technology (id_project, id_technology)
    values(3, 8);
        
insert into project_technology (id_project, id_technology)
    values(4, 11);
        
insert into project_technology (id_project, id_technology)
    values(4, 13);
