#!/bin/bash  
  

login=${{ secrets.DOCKERHUB_LOGIN }}
password=${{ secrets.DOCKERHUB_PASSWORD }}
image="$login"/${{ secrets.DOCKERHUB_IMAGE }}

echo "IMAGE_NAME = $image"
timestamp=$(date +%Y%m%d%H%M%S)  
  
tag=$image:$timestamp  
echo "TAG = $tag"

latest=$image:latest

docker build -f src/OrioksServer/Dockerfile -t $tag .  

echo "$password" | docker login -u "$login" --password-stdin  
docker push $image  

docker system prune -f 
