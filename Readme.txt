Installation + configuration suivre : http://chewbii.com/wp-content/uploads/2015/11/MongoDB_guide.pdf

Lancer le serveur mongoDB : 
(ex : C:\Program Files\MongoDB\Server\3.4\bin\mongod.exe)

Cr�er la base de donn�es sakila
	Tuto sous studio 3T :
		Ajoutez une nouvelle base de donn�e au nom de "sakila" : Docs\img\img1.png
		Docs\img\img2.png
		Une fois la base de donn�e cr�e il faut importer les collections : Docs\img\img3.png

Importer les collections Dans "\Data\Sakila collection Transformed" (json conseill�)
	Tuto sous studio 3T :
		Clic droit sur la base de donn�e "sakila" et Importer les collections : Docs\img\img4.png
		S�lectionnez JSON,
		puis le bouton +,
		S�lectionnez tous les fichiers json dans "\Data\Sakila collection Transformed" : Docs\img\img5.png
		Puis cliquez sur Next, Next et Start Import
		Vous devriez avoir le r�sultat suivant : Docs\img\img6.png 

Toujours le serveur lanc� ouvrez la solution : DarkMongouille\DarkMongouille.sln avec visual studio et cliquez sur "Start"
Ou bien : DarkMongouille\DarkMongouille\bin\Debug\DarkMongouille.exe

Les identifiants et mots de passe pour chaque utilisateurs sont :
Utilisateur standard : 
username : standard
password : 1234

Utilisateur Analyste/Decisionnaire :
username : business
password : business

Administrateur : 
username : admin
password : admin




