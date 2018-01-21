# Developpement d'application Cloud

## Installation :

Installation + configuration suivre : http://chewbii.com/wp-content/uploads/2015/11/MongoDB_guide.pdf

## Lancement du mongoDB :
Une fois mongoDB installé : 
- Lancer le serveur mongoDB : (ex : C:\Program Files\MongoDB\Server\3.4\bin\mongod.exe)

## Création de la base de données sakila :

- Créer la base de données sakila
	
	Tuto sous studio 3T :
		
		Ajoutez une nouvelle base de donnée au nom de "sakila" :
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img1.png?raw=true)
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img2.png?raw=true)
		
		Une fois la base de donnée crée il faut importer les collections :
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img3.png?raw=true)

- Importer les collections Dans "\Data\Sakila collection Transformed" (json conseillé)
	
	Tuto sous studio 3T :
		
		Clic droit sur la base de donnée "sakila" et Importer les collections :
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img4.png?raw=true)
		
		Sélectionnez JSON,
		
		puis le bouton +,
		
		Sélectionnez tous les fichiers json dans "\Data\Sakila collection Transformed" :
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img5.png?raw=true)
		
		Puis cliquez sur Next, Next et Start Import
		
		Vous devriez avoir le résultat suivant :
		
![alt text](https://github.com/yasmeentrifiss/DarkMongouille/blob/master/Docs/img/img6.png?raw=true)

## Lancement de l'application :

- Toujours le serveur lancé ouvrez la solution : DarkMongouille\DarkMongouille.sln avec visual studio et cliquez sur "Start"
- Ou bien : DarkMongouille\DarkMongouille\bin\Debug\DarkMongouille.exe

## Identifiants et mots de passe :

Les identifiants et mots de passe pour chaque utilisateurs sont :


Utilisateur standard :
	- username : standard
	- password : 1234

Utilisateur Analyste/Decisionnaire :
	- username : business
	- password : business

Administrateur : 
	- username : admin
	- password : admin