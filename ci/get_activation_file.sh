#!/usr/bin/env bash

activation_file=${UNITY_ACTIVATION_FILE:-./unity3d.alf}

if [[ -z "${UNITY_USERNAME}" ]] || [[ -z "${UNITY_PASSWORD}" ]]; then
  echo "UNITY_USERNAME or UNITY_PASSWORD environment variables are not set, please refer to instructions in the readme and add these to your secret environment variables."
  exit 1
fi

xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' \
  unity-editor \
    -logFile /dev/stdout \
    -batchmode \
    -nographics \
    -username "$UNITY_USERNAME" -password "$UNITY_PASSWORD" |
      tee ./unity-output.log

cat ./unity-output.log |
  grep 'LICENSE SYSTEM .* Posting *' |
  sed 's/.*Posting *//' > "${activation_file}"

# Fail job if unity.alf is empty
ls "${UNITY_ACTIVATION_FILE:-./unity3d.alf}"
exit_code=$?

if [[ ${exit_code} -eq 0 ]]; then
  echo ""
  echo ""
  echo "### Congratulations! ###"
  echo "${activation_file} was generated successfully!"
  echo ""
  echo "### Next steps ###"
  echo ""
  echo "Complete the activation process manually"
  echo ""
  echo "   1. Download the artifact which should contain ${activation_file}"
  echo "   2. Visit https://license.unity3d.com/manual"
  echo "   3. Upload ${activation_file} in the form"
  echo "   4. Answer questions (unity pro vs personal edition, both will work, just pick the one you use)"
  echo "   5. Download 'Unity_v2019.x.ulf' file (year should match your unity version here, 'Unity_v2018.x.ulf' for 2018, etc.)"
  echo "   6. Copy the content of 'Unity_v2019.x.ulf' license file to your CI's environment variable 'UNITY_LICENSE'. (Open your project's parameters > CI/CD > Variables and add 'UNITY_LICENSE' as the key and paste the content of the license file into the value)"
  echo ""
  echo "Once you're done, hit retry on the pipeline where other jobs failed, or just push another commit. Things should be green"
  echo ""
  echo "(optional) For more details on why this is not fully automated, visit https://gitlab.com/gableroux/unity3d-gitlab-ci-example/issues/73"
else
  echo "License file could not be found at ${UNITY_ACTIVATION_FILE:-./unity3d.alf}"
fi
exit $exit_code
