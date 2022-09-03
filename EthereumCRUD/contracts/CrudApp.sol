pragma solidity ^0.4.23;

contract CrudApp {
    
   struct exampleModel{
      uint256 id;
      string name;
      uint256 modelValue;
   }
  
   exampleModel[] public models; 

  
    constructor() public {

   }

   event ModelCreatedEvent(uint256 id, string modelName, uint256 modelValue);
   
   event NameUpdated(uint256 id, string modelName);

   event ModelDelete(string modelName);

    
   function insert( uint256 id, string modelName, uint256 modelValue) public returns (uint256 totalModels){
       for(uint256 i =0; i< models.length; i++){
           if(models[i].id == id){
              revert('Model o danym id juz zostal dodany');
           }
       }
        exampleModel memory newCountry = exampleModel(id, modelName, modelValue);
        models.push(newCountry);
        emit ModelCreatedEvent (id, modelName, modelValue);
        return models.length;
   }
   
   function updateName(uint256 id, string modelName) public returns (bool success){
       for(uint256 i =0; i< models.length; i++){
           if(models[i].id == id){
              models[i].name = modelName;
              emit NameUpdated(id, modelName);
              return true;
           }
       }
       return false;
   }
   
   function deleteModel(uint256 id) public returns(bool success){
        require(models.length > 0);
        for(uint256 i =0; i< models.length; i++){
           if(models[i].id == id){
              string modelName = models[i].name;
              models[i] = models[models.length-1];
              delete models[models.length-1];
              emit ModelDelete(modelName);
              return true;
           }
       }
       return false;
   }
   
     
   function getModel(uint256 id) public view returns(uint256 identifier, string modelName, uint256 modelValue){
        for(uint256 i =0; i< models.length; i++){
           if(models[i].id == id){
              return (models[i].id , models[i].name , models[i].modelValue);
           }
       }
       revert('exampleModel not found');
   }     
}