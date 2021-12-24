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
    values('Floran', 'Houdart', '$2a$11$zZ9V3CPBRH5BXiAmf70TNOvhCJLG/bt0GN2V6aUtSzoaYHZzG6UMq', 'floran.houdart@gmail.com', 1, convert(date, '11-01-2001', 103)
        , './assets/images/profilePictures/floran_houdart.jpg');

/*zuck*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Mark', 'Zuckerberg', '$2a$11$zC.3DpLEjifSQQ5NkFQv2eb9SFoN8rAxLSoNFVlX1U7zISqQZXPfW', 'zuck@facebook.com', 3, convert(date, '14-05-1984', 103));

/*tesla*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Elon', 'Musk', '$2a$11$4dZxukSdA1p8g.Q1Pj4H7eMTRSVNgG8c7fzzR0TEbX1x9TOidc4W6', 'elon.musk@tesla.com', 1, convert(date, '28-06-1971', 103));

/*bertin*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('John', 'Bertin', '$2a$11$3inFr2oGXFHRYL.IrBwkoeGOftc7Cw2LDp/fDrUTcbxKirpicIE52', 'john.bertin@gmail.com', 1, convert(date, '24-10-1994', 103));

/*guyot*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Pierre', 'Guyot', '$2a$11$B9L6A6U39zy.WsjrGbJwyuqo2kxfeFk4EVRj/RUapeGFinOIGtXhe', 'pierre.guyot@gmail.com', 2, convert(date, '14-08-2000', 103));

/*squeezie*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
    values('Lucas', 'Hauchard', '$2a$11$lP0oA3.lnMV6yd69sgwqZ.HbhyEOGrHtf8a/2tTTTPO1ko5iak5li', 'lucas.hauchard@squeezie.industries.fr', 2, convert(date, '27-01-1996', 103));

/*comedian*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Dane', 'Cook', '$2a$11$Re4CmL8wzytLprJQktRDxe7aSe5siwipz12qQ.AcgpNZgOb3TBi6.', 'dane.cook@gmail.com', 1, convert(date, '18-03-1972', 103));

/*swimmer*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Lynne', 'Cox', '$2a$11$4HReK1PJ9O9l9z1AMucWe.ldnCiJOejv.HplD.Tlw6ZdE.GkzunU6', 'lynne.cox@gmail.com', 2, convert(date, '02-01-1957', 103));

/*corporation*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Richard', 'Egan', '$2a$11$V9fMyF.1BKJ1QD.ePeIQ0.TTq5kikREgZ22j2GN2W8lX/72CA/Zt.', 'richard.egan@gmail.com', 3, convert(date, '20-07-1987', 103));

/*serie*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Paul', 'Glaser', '$2a$11$vlgmNlLMbE/sQgOPw8cNE.ypbdzuVXZqWkeSmFbV6M35OyXzFCfO.', 'paul.glaser@gmail.com', 1, convert(date, '25-03-1943', 103));

/*hockey*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Bill', 'Guerin', '$2a$11$7bn240sAmq5wUR5V21gT4.D/CoC7gM1utm8IfYzoy87EyyO7CiwNy', 'bill.guerin@gmail.com', 1, convert(date, '09-11-1970', 103));

/*football*/
insert into sos_user(firstname, lastname, password, email, role, birthdate)
values('Darin', 'Jordan', '$2a$11$r41cISQ6tMIJDXWDFL02VuSAKgSwsfr30T7n0uONBmx7OrRUeJ.E2', 'darin.jordan@gmail.com', 1, convert(date, '04-12-1964', 103));


/*Init projects*/
insert into project( name, deadline, description, repository_url, sos_status)
    values( 'ScrumOrganisationSuccess API', convert(datetime, '24-02-2022 12:00:00', 103), 'Serveur pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessAPI', 2);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'ScrumOrganisationSuccess Web App', convert(datetime, '24-02-2022 12:00:00', 103), 'Site pour réussir son année',
    'https://github.com/Scryper/ScrumOrganisationSuccessWebApp', 2);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'Skydda', convert(datetime, '08-03-2022 12:00:00', 103), 'Jeu vidéo pour réussir son année',
    'https://github.com/Scryper/Skydda', 3);

insert into project( name, deadline, description, repository_url, sos_status)
    values( 'Labo TCP IP', convert(datetime, '08-02-2022 12:00:00', 103), 'Labo pour réussir son année',
    'https://github.com/Scryper/Labo01_TCP_IP', 3);

insert into project( name, deadline, description, repository_url, sos_status)
values('Dernier Projet', convert(datetime, '30-01-2022 12:00:00', 103), 'projet pour réussir son année',
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
    values(1, 1, convert(date, '01-01-2022', 103), convert(date, '31-01-2022', 103), 'Création basique du serveur');
   
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(1, 2, convert(date, '01-02-2022', 103), convert(date, '15-02-2022', 103), 'Liens entre API, application internet et application android');

insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(1, 3, convert(date, '16-02-2022', 103), convert(date, '24-02-2022', 103), 'Derniers réglages en fonctions des demandes du client');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(2, 1, convert(date, '06-01-2022', 103), convert(date, '19-01-2022', 103), 'Premier jet des pages du site');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(2, 2, convert(date, '20-01-2022', 103), convert(date, '24-02-2022', 103), 'Deuxième jet des pages du site');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 1, convert(date, '10-01-2022', 103), convert(date, '11-01-2022', 103), 'Ajout des premiers mouvements');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 2, convert(date, '12-01-2022', 103), convert(date, '10-02-2022', 103), 'Ajout des personnages et maps');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(3, 3, convert(date, '11-02-2022', 103), convert(date, '08-03-2022', 103), 'Finitions, améliorations, factorisation');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(4, 1, convert(date, '30-12-2022', 103), convert(date, '15-01-2022', 103), 'Création du visuel des pages');
    
insert into sprint(id_project, sprint_number, start_date, deadline, description)
    values(4, 2, convert(date, '16-01-2022', 103), convert(date, '08-02-2022', 103), 'Création du back-end des pages');

/*Init user stories*/
insert into user_story(id_project, name, description, priority)
    values(1, 'Database en SQL', 'Créer une base de données en SQL server pour l''API.', 1);
    
insert into user_story(id_project, name, description, priority)
    values(1, 'Création des uses cases', 'Création de chaque user case pour le serveur.', 2);

insert into user_story(id_project, name, description, priority)
    values(1, 'Tests unitaires', 'Vérifier chaque calcul effectué ainsi que le format des données entrées.', 3);

insert into user_story(id_project, name, description, priority)
    values(1, 'Sécurité pour le login', 'Créer la sécurité pour le login d''un utilisateur.', 4);
    
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
    values(1, convert(datetime, '24-01-2022 22:00:00', 103), 'Meeting pour réussir son année.','PrivateHelhaRoom1');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(1, convert(datetime, '25-01-2022 12:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom7');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(1, convert(datetime, '25-01-2022 19:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom2');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(2, convert(datetime, '02-02-2022 12:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom3');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(2, convert(datetime, '10-02-2022 15:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom4');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '17-02-2022 15:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom5');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '22-02-2022 15:00:00', 103), 'Partage des tâches restantes.','PrivateHelhaRoom6');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(3, convert(datetime, '23-02-2022 15:00:00', 103), 'Organisation de la présentation orale.','PrivateHelhaRoom8');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(4, convert(datetime, '07-01-2022 15:00:00', 103), 'Partage des tâches.','PrivateHelhaRoom9');
    
insert into meeting(id_sprint, schedule, description, meeting_url)
    values(4, convert(datetime, '15-01-2022 15:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom10');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '24-01-2022 15:00:00', 103), 'Partage des tâches.','PrivateHelhaRoom11');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '24-01-2022 19:00:00', 103), 'Mise en commun des branches.','PrivateHelhaRoom12');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '25-01-2022 15:00:00', 103), 'Mise en commun des branches21.','PrivateHelhaRoom1221');

insert into meeting(id_sprint, schedule, description, meeting_url)
values(5, convert(datetime, '25-01-2022 19:00:00', 103), 'Mise en commun des branches22.','PrivateHelhaRoom1222');

/*Init comments*/
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 1, convert(datetime, '20-01-2022 12:00:00', 103), 'Bug sur cette User story, quelqu''un de dispo ?');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 2, convert(datetime, '20-01-2022 12:30:00', 103), 'Je suis disponible, on se rejoint sur Discord');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(1, 5, convert(datetime, '21-01-2022 12:30:00', 103), 'Vous en êtes où ?');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 6, convert(datetime, '02-12-2021 12:30:00', 103), 'Les tests sont finis ?');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 2, convert(datetime, '02-12-2021 13:30:00', 103), 'Absolument pas, c''est en retard même');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(3, 3, convert(datetime, '03-12-2021 13:34:00', 103), 'Qui a push dans la branche master ?');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 3, convert(datetime, '10-10-2021 13:34:00', 103), 'Je viens de rejoindre, une petite explication ?');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(10, 1, convert(datetime, '10-10-2021 13:35:00', 103), 'On s''attaque au back-end de l''application');
    
insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 8, convert(datetime, '10-12-2021 13:35:00', 103), 'Tu peux faire les calculs de masques si tu n''as pas encore de tâches');

insert into comment(id_user_story, id_user, posted_at, content)
    values(7, 9, convert(datetime, '10-12-2021 13:35:00', 103), 'J''ai finis ma partie, qu''est ce qu''il reste encore ?');

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
