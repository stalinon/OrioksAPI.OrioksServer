#!/bin/bash  
  

login="$DOCKER_LOGIN"
password="$DOCKER_PASSWORD"
image="$login"/"$DOCKER_IMAGE"

echo "IMAGE_NAME = $image"
timestamp=$(date +%Y%m%d%H%M%S)  
  
tag=$image:$timestamp  
echo "TAG = $tag"

latest=$image:latest

docker build -f src/OrioksServer/Dockerfile -t $tag .  

echo "$password" | docker login -u "$login" --password-stdin  
docker push $image  

docker system prune -f 
