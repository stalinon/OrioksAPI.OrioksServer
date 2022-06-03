#!/bin/bash
docker login
docker pull stalinon/orioksserver
docker container rm -f orioksserver
docker container run --name orioksserver -p 5000:5000 --network os_db_network --env-file server.env --rm -d stalinon/orioksserver
