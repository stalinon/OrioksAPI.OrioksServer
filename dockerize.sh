#!/bin/bash  
  

login="$1"
password="$2"
image="$login"/"$3"

echo "IMAGE_NAME = $image"
timestamp=$(date +%Y%m%d%H%M%S)  
  
tag=$image:$timestamp  
echo "TAG = $tag"

latest=$image:latest

docker build -f src/OrioksServer/Dockerfile -t $tag .  

echo "$password" | docker login -u "$login" --password-stdin  
docker push $tag

docker system prune -f 
