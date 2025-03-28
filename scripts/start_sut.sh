#!/bin/bash

# Client
echo "Starting Client"
cd client && npm start &

# Server
echo "Starting Server"

cd server && npm start &

# Wait for processes to finish
wait
