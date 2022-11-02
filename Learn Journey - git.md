# 创建ssh key
cd ~/.ssh
ls
ssh-keygen -t rsa -C "your_email@example.com"
将生成的pub文件传至git仓库
ssh -T git@github.com   测试连接

# 修改本地git项目的远程目标地址
.git/config  内修改remote origin url
