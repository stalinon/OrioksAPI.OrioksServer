#!/bin/bash  


echo "IMAGE_NAME = $DOCKER_IMAGE"
timestamp=$(date +%Y%m%d%H%M%S)  
  
tag=$DOCKER_IMAGE:$timestamp  
echo "TAG = $tag"

latest=$DOCKER_IMAGE:latest

docker build -f src/OrioksServer/Dockerfile -t $tag .  

echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_LOGIN" --password-stdin  
docker push $DOCKER_IMAGE  

docker system prune -f 
