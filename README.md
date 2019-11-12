# Unity-Object-Pooler
 This is an object pooler project for Unity
 
 ![square](https://user-images.githubusercontent.com/32217921/68706051-36c4e100-05a0-11ea-9136-b5fc3f5f396c.gif)
 
 You can clone or download the project directly, or download the package from releases section and import it to your project.
 
 ## How To Use
 
 Create object pool on ObjectPooler with an object prefab and pool size value
 ![Screenshot (32)](https://user-images.githubusercontent.com/32217921/68706393-d1bdbb00-05a0-11ea-851a-28fccdd1f8be.png | height=100)

Reuse from the pool with the same GameObject reference that was used for creating the pool.
Resue method has two overloads. Last transform parameter is for parenting the object. (Like Unity's Instantiate method)
![Screenshot (33)](https://user-images.githubusercontent.com/32217921/68706708-60323c80-05a1-11ea-88d3-a640eb1e818c.png)

If you include IReusable on the reused object class, object pooler will call Reuse method everytime the object is reused.
![Screenshot (34)](https://user-images.githubusercontent.com/32217921/68706884-be5f1f80-05a1-11ea-81ab-b008dbf49104.png)

The following is the sample Reuse method
![Screenshot (34) - Copy](https://user-images.githubusercontent.com/32217921/68707013-fcf4da00-05a1-11ea-874c-5514a0a49359.png)
