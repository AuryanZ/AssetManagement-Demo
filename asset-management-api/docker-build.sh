#!/bin/bash

# Start all services except assetsapi
docker-compose up -d msdb

# Wait for msdb to become healthy
echo "Waiting for msdb to become ready..."
while [ "$(docker-compose ps msdb | grep 'Up (healthy)')" == "" ]; do
    sleep 5
done

# Now, build and start assetsapi
docker-compose up -d --build assetsapi
