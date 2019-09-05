#!/bin/bash

echo ">> shell script is running..."

commits=`git rev-list --all --count`
now=$(date -d '+2 hour' +'%R %Y-%m-%d')
echo "{\"commits\":\"$commits\", \"last_push\":\"$now\"}" > badges.json