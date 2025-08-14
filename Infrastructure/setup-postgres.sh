

#!/bin/sh

# Load database variables from .env file
#if [ -f ../.env ]; then
#  export $(cat ../.env | grep -v '^#' | xargs)
#else
#  echo "Error: .env file not found."
#  exit 1
#fi
#
## Check if the required environment variables are set
#if [ -z "$DATABASE_NAME" ] || [ -z "$DATABASE_USERNAME" ] || [ -z "$DATABASE_PASSWORD" ]; then
#  echo "Error: One or more required environment variables (DATABASE_NAME, DATABASE_USERNAME, DATABASE_PASSWORD) are not set."
#  exit 1
#fi
#
## Use the environment variables
#echo "Database Name: $DATABASE_NAME"
#echo "Database Username: $DATABASE_USERNAME"
#echo "Database Password: $DATABASE_PASSWORD"

# Pull the latest PostgreSQL Docker image
docker pull postgres:latest

# Run the PostgreSQL container
echo "Starting PostgreSQL container..."
if ! docker run --name relos \
  -e POSTGRES_USER=relos \
  -e POSTGRES_PASSWORD=relos\
  -e POSTGRES_DB=relos \
  -p 5432:5432 \
  -d postgres:latest; then
  echo "Error: Failed to start PostgreSQL container."
  exit 1
fi


echo "PostgreSQL container running successfully...."