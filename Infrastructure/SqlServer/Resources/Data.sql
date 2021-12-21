/*Init users*/
/*scryper*/
insert into sos_user(firstname, lastname, password, email, role, birthdate, profile_picture)
    values('Florian', 'Mazzeo', '$2a$11$5y2KG.K8bFlI5dfELDfa4eBEfJIADR1w3s6AUy7WfgmE2UxTHO7bO', 'florian.mazzeo@gmail.com', 1, convert(date, '20-12-2001', 103)
        , './assets/images/profilePictures/florian_mazzeo.jpg');

/*damien97*/
insert into sos_user(firstname, lastname, password, email, role, birthdate, profile_picture)
    values('Damien', 'Auversack', '$2a$11$509d8kS5yzSunKES0J783.DZpLx.XnMlFeKH5wgHcRnSVkzSxaShu', 'damsover@gmail.com', 2, convert(date, '23-07-1997', 103)
        , './assets/images/profilePictures/damien_auversack.jpg');

/*dotni*/
insert into sos_user(firstname, lastname, password, email, role, birthdate, profile_picture)
    values('Martin', 'Maes', '$2a$11$BRuCITwYepTWRRbm25qEgeK5q2bH.bQrtR4w01c4P0E.Egj865yPO', 'martin.maes100.000@gmail.com', 3, convert(date, '26-11-1998', 103)
        , './assets/images/profilePictures/martin_maes.jpg');

/*myneck*/
insert into sos_user(firstname, lastname, password, email, role, birthdate, profile_picture)
    values('Floran', 'Houdart', '$2a$11$zZ9V3CPBRH5BXiAmf70TNOvhCJLG/bt0GN2V6aUtSzoaYHZzG6UMq', 'la199788@student.helha.be', 1, convert(date, '11-01-2001', 103)
        , './assets/images/profilePictures/floran_houdart.jpg');

/*zuck*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Mark', 'Zuckerberg', '$2a$11$zC.3DpLEjifSQQ5NkFQv2eb9SFoN8rAxLSoNFVlX1U7zISqQZXPfW', 'zuck@facebook.com', 3, convert(date, '14-05-1984', 103));

/*tesla*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Elon', 'Musk', '$2a$11$4dZxukSdA1p8g.Q1Pj4H7eMTRSVNgG8c7fzzR0TEbX1x9TOidc4W6', 'elon.musk@tesla.com', 1, convert(date, '28-06-1971', 103));

/*laref*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Patrick', 'Onatenpa', '$2a$11$GEUFBYTcGFqZECEoz849reToY5.oa7EhYFuyVGCHfryECxOHJuDQy', 'onatenpa.patrick@camping.fr', 1, convert(date, '24-10-1994', 103));

/*choisi*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Vouza', 'Vaibien', '$2a$11$umlGXv4DwE.QEfQ6BP3nk.52MX6MyaRQseFvh7pGjqj2xnW9lJs.G', 'techniquecellela@vandenborre.be', 2, convert(date, '14-08-2000', 103));

/*squeezie*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Lucas', 'Hauchard', '$2a$11$lP0oA3.lnMV6yd69sgwqZ.HbhyEOGrHtf8a/2tTTTPO1ko5iak5li', 'lucas.hauchard@squeezie.industries.fr', 2, convert(date, '27-01-1996', 103));

/*Init projects*/
insert into project( name, deadline, description, repository_url, sos_status)
    values( 'ScrumOrganisationSuccess API', convert(datetime, '24-12-2021 12:00:00', 103), 'Serveur pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessAPI', 2);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'ScrumOrganisationSuccess Web App', convert(datetime, '24-12-2021 12:00:00', 103), 'Site pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessWebApp', 2);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'Skydda', convert(datetime, '08-12-2021 12:00:00', 103), 'Jeu vidéo pour réussir son année',
    'https://github.com/Scryper/Skydda', 3);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'Labo TCP IP', convert(datetime, '08-12-2021 12:00:00', 103), 'Labo pour réussir son année',
    'https://github.com/Scryper/Labo01_TCP_IP', 3);

insert into project( name, deadline, description, repository_url, sos_status)
values('Dernier Projet', convert(datetime, '09-12-2021 12:00:00', 103), 'projet pour réussir son année',
        'https://github.com/dotni/meilleurProjet', 2);

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
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(1, 1, convert(date, '01-11-2021', 103), convert(date, '14-11-2021', 103), 'Création basique du serveur');
   
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(1, 2, convert(date, '15-11-2021', 103), convert(date, '15-12-2021', 103), 'Ajout des dernières fonctionnalités nécessaires');

insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(1, 3, convert(date, '19-12-2021', 103), convert(date, '24-12-2021', 103), 'Ajout des vraies dernières fonctionnalités nécessaires');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(2, 1, convert(date, '06-11-2021', 103), convert(date, '19-11-2021', 103), 'Premier jet des pages du site');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(2, 2, convert(date, '20-11-2021', 103), convert(date, '20-12-2021', 103), 'Deuxième jet des pages du site');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 1, convert(date, '10-09-2021', 103), convert(date, '09-10-2021', 103), 'Ajout des premiers mouvements');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 2, convert(date, '10-10-2021', 103), convert(date, '10-11-2021', 103), 'Ajout des personnages et maps');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 3, convert(date, '11-11-2021', 103), convert(date, '11-12-2021', 103), 'Finitions, améliorations, factorisation');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(4, 1, convert(date, '10-10-2021', 103), convert(date, '23-10-2021', 103), 'Création du visuel des pages');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(4, 2, convert(date, '24-10-2021', 103), convert(date, '24-11-2021', 103), 'Création du back-end des pages');

/*Init user stories*/
insert into user_story(id_project, name, description, priority)
    values(1, 'User story pour réussir son année.', 'On va réussir wola.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(1, 'Encore une user story.', 'On va réussir vraiment.', 2);

insert into user_story(id_project, name, description, priority)
    values(1, 'Encore une user story mais pas la même.', 'On va réussir vraiment pour de vrai.', 3);

insert into user_story(id_project, name, description, priority)
    values(1, 'Encore une user story mais différente.', 'Bugounet est vaincu.', 3);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En  tant que visiteur, je peux m''inscrire.', 'Un visiteur sur le site peut s''inscrire si son adresse mail n''est pas déjà présente dans la base de donnée.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En tant qu''utilisateur inscrit, je peux me connecter.', 'L''utilisateur qui s''est inscrit peut se connecter à son compte.', 2);
    
insert into user_story(id_project, name, description, priority)
    values(2, 'En tant qu''utilisateur, je peux consulter ma liste de meetings prévus.', 'L''utilisateur de n''importe quel type, peut consulter un calendrier contenant tout les meetings auquel il est convié.', 3);

insert into user_story(id_project, name, description, priority)
    values(2, 'En tant que scrum master, je peux ajouter des meetings.', 'Le scrum master peut créer des meetings auquel il convie les développeurs et/ou le product owner.', 4);

insert into user_story(id_project, name, description, priority)
    values(3, 'En tant que joueur, je peux sauter.', 'Le joueur peut sauter grâce aux touches affectées.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(3, 'En tant que joueur, je peux attaquer mon adversaire.', 'Le joueur peut ataquer l''adversaire et lui faire subir des dégâts grâce aux touches affectées.', 2);
    
insert into user_story(id_project, name, description, priority)
    values(3, 'En tant qu''utilisateur, je peux modifier le voolume de la musique de fond.', 'L''utilisateur peut modifier le volume de la musique de fond. La valeur varie entre 0 et 100.', 3);

insert into user_story(id_project, name, description, priority)
    values(4, 'En tant qu''utilisateur je peux naviguer sur le site.', 'L''utilisateur peut choisir sur quel page il veut aller.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(4, 'En tant qu''utilisateur je peux revenir sur la page d''acceuil.', 'L''utilisateur peut revenir sur la page d''accueil, et ce depuis n''importe quel autre page du site.', 2);

/*Init meetings*/
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(1, convert(datetime, '21-12-2021 12:00:00', 103), 'Meeting pour réussir son année.','PrivateHelhaRoom1');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(1, convert(datetime, '05-12-2021 12:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom7');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(1, convert(datetime, '12-11-2021 12:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom2');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(2, convert(datetime, '20-11-2021 12:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom3');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(2, convert(datetime, '14-12-2021 15:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom4');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '08-11-2021 15:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom5');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '14-11-2021 15:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom6');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '18-11-2021 15:00:00', 103), 'Organisation de la présentation orale.','PrivateHelhaRoom8');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(4, convert(datetime, '01-12-2021 15:00:00', 103), 'Partage des tâches.','PrivateHelhaRoom9');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(4, convert(datetime, '21-12-2021 15:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom10');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '22-12-2021 15:00:00', 103), 'Partage des tâches.','PrivateHelhaRoom11');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '21-12-2021 15:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom12');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '21-12-2021 15:00:00', 103), 'Mise en commun des branches21.','PrivateHelhaRoom1221');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '22-12-2021 15:00:00', 103), 'Mise en commun des branches22.','PrivateHelhaRoom1222');

/*Init comments*/
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 1, convert(datetime, '26-11-2021 12:00:00', 103), 'Commentaire pour réussir son année.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 2, convert(datetime, '26-11-2021 12:30:00', 103), 'Tu as raison.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 6, convert(datetime, '26-11-2021 12:30:00', 103), 'Tu es embauché.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 6, convert(datetime, '02-12-2021 12:30:00', 103), 'Eeeeh vous me copiez la.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 2, convert(datetime, '02-12-2021 13:30:00', 103), 'Mais pas du tout ????!!!! C''est quand même normal de pouvoir s''inscrire sur un site!!!');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 3, convert(datetime, '03-12-2021 13:34:00', 103), 'De fou détends toi le zuck.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 3, convert(datetime, '10-10-2021 13:34:00', 103), 'Le bateeeauuu naviiiigueeeee.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 1, convert(datetime, '10-10-2021 13:35:00', 103), 'T''es ravagé toi.');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 8, convert(datetime, '10-12-2021 13:35:00', 103), 'Je veux voir vos têtes vous dateeeeeez!');

insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 9, convert(datetime, '10-12-2021 13:35:00', 103), 'Oh non pas lui....');

/*Init project_user link table*/
insert into user_project(id_project, id_user, is_appliance)
    values(1, 1, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(1, 2, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(3, 1, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(1, 4, 0);
    
insert into user_project(id_project, id_user, is_appliance)
    values(4, 1, 0);
    
insert into user_project(id_project, id_user, is_appliance)
    values(1, 7, 0);
    
insert into user_project(id_project, id_user, is_appliance)
    values(4, 7, 0);
    
insert into user_project(id_project, id_user, is_appliance)
    values(1, 6, 0);
    
insert into user_project(id_project, id_user, is_appliance)
    values(4, 6, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(1, 5, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(5, 3, 0);

insert into user_project(id_project, id_user, is_appliance)
    values(2, 4, 0);

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

insert into sprint_user_story(id_sprint, id_user_story)
    values(3, 3);

insert into sprint_user_story(id_sprint, id_user_story)
    values(4, 4);
 
insert into sprint_user_story(id_sprint, id_user_story)
    values(4, 5);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(5, 6);

insert into sprint_user_story(id_sprint, id_user_story)
    values(5, 7);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(6, 8);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(7, 9);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(8, 10);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(9, 11);
    
insert into sprint_user_story(id_sprint, id_user_story)
    values(10, 12);

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
