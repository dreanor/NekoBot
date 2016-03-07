# NekoBot
[![Build status](https://ci.appveyor.com/api/projects/status/fjlpei28tsfwfd1i?svg=true)](https://ci.appveyor.com/project/dreanor/nekobot)

Discord Bot that posts random cat images. Since Discord is limited to 10 messages every 2 seconds there are limiters to prevent overflows.

##How to run:
Change the email and password in the [config.json](https://github.com/dreanor/NekoBot/blob/master/NekoBot/config.json)

###Commands:
| Command | Description | Permission |
| ------------- | ------------- | ------------- |
| /cat  | Posts a random cat link from http://random.cat/  | @everyone |
| /music | Posts meme music from http://nigge.rs/ | @everyone |
| /translate 'Text to translate' de | Translates the text to the given country code | @everyone |
| /8ball | Anwsers all your questions truthfully | @everyone |
| /clear | Clears the entire chat history of the current channel. | Role in AdminCommandUserRoles |
| /delete 1 | Deletes the last amount of messages in the current channel | Role in AdminCommandUserRoles |
| /reload | Reloads the config.json | Role in AdminCommandUserRoles |
