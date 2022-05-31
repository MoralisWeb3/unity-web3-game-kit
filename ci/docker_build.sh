#!/usr/bin/env bash

set -e

docker run \
  -e BUILD_NAME \
  -e UNITY_LICENSE \
  -e BUILD_TARGET \
  -e UNITY_USERNAME \
  -e UNITY_PASSWORD \
  -w /project/ \
  -v $UNITY_DIR:/project/ \
  $IMAGE_NAME \
  /bin/bash -c "/project/ci/before_script.sh && /project/ci/build.sh"
