import os


import os
import json
import fileinput

config_file_path = '../HiddenSolutionsClient/appsettings.Development.json'
def changeApiBaseUrl(baseUrl):
    with open(config_file_path, 'r') as config_file:
        data = json.load(config_file)
        data['Api']['BaseUrl'] = baseUrl

    os.remove(config_file_path)
    with open(config_file_path, 'w') as f:
        json.dump(data, f, indent=4)


changeApiBaseUrl('https://hiddensolutionsapi.herokuapp.com')

os.system('cd .. && cd HiddenSolutionsClient && sudo docker build -t hiddensolutionsclient .')
os.system('cd .. && cd HiddenSolutionsClient && sudo heroku container:push web -a hiddensolutionsclient')
os.system('cd .. && cd HiddenSolutionsClient && sudo heroku container:release web -a hiddensolutionsclient')

changeApiBaseUrl('http://localhost:5000')
