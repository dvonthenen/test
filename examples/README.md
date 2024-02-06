# Examples for Testing Features Locally

The example projects are meant to be used to test features locally by contributors working on this SDK.

## Prerequisites

In order to run the code in the `examples` folder, you first need to install/pip the dependencies contained in the `requirements-examples.txt` for the examples.

```bash
pip install -r requirements-examples.txt
```

## Steps to Test Your Code

If you are contributing changes to this SDK, you can test those changes by using the `prerecorded`, `streaming`, or `manage` "hello world"-style applications in the `examples` folder. Here are the steps to follow:

### Set your API Key as an Environment Variable named "DEEPGRAM_API_KEY"

If using bash, this could be done in your `.bash_profile` like so:

```bash
export DEEPGRAM_API_KEY = "YOUR_DEEPGRAM_API_KEY"
```

or this could also be done by a simple export before executing your python application:

```bash
DEEPGRAM_API_KEY="YOUR_DEEPGRAM_API_KEY" python main.py
```

### Run the project

If you chose to set an environment variable in your shell profile (ie `.bash_profile`) you can change directory into each example folder and run the example like so:

```bash
python main.py
```
