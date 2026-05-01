# PHP 集成环境

一款使用 C# 编写的 PHP 集成环境管理工具，用于快速部署和管理 PHP 开发环境。

## 项目简介

本项目是一款可视化的 PHP 集成环境管理工具，内置 Phalcon、Yaf 等热门 PHP 框架，支持一键启动 Nginx、PHP、MySQL 等服务。

## 截图

| 主界面 | 服务管理 |
|:---:|:---:|
| ![主界面](http://b389.photo.store.qq.com/psb?/V14SCHEg0Zq4JL/RuVc6sxT1F*jCKPVOIL2aMyhjejnc6rQKDDtkWCzmJI!/c/dIUBAAAAAAAA&bo=PgE1AT4BNQEDACU!&rf=mood_app) | ![服务管理](http://b389.photo.store.qq.com/psb?/V14SCHEg0Zq4JL/92yuV*HGsJyc3WMSHgrHnxnLAUln8v4H2fN3MwPdDhQ!/c/dIUBAAAAAAAA&bo=XAFFAVwBRQEDACU!) |


## 功能特性

| 功能 | 说明 |
|:---|:---|
| 可视化管理 | 图形化界面，轻松管理 PHP 服务 |
| 多版本支持 | 支持 PHP 5.3 ~ PHP 7.0 多个版本 |
| 框架集成 | 内置 Phalcon、Yaf 框架 |
| 服务控制 | 快速启动/停止 Nginx、PHP、MySQL 服务 |

## 技术栈

| 类别 | 技术 |
|:---|:---|
| 开发语言 | C# (.NET) |
| UI 框架 | Windows Forms |
| Web 服务器 | Nginx |
| PHP 版本 | 5.3 / 5.4 / 5.5 / 5.6 / 7.0 |
| 数据库 | MySQL |

## 目录结构

```
php_env/
├── php_env/                      # 主程序目录
│   ├── MainForm.cs               # 主窗体逻辑
│   ├── MainForm.Designer.cs      # 窗体设计器
│   ├── Tool.cs                   # 辅助工具类
│   ├── XmlExt.cs                 # XML 配置解析
│   ├── Program.cs                # 程序入口
│   └── Properties/               # 程序集信息
├── README.md                     # 项目文档
└── app.sln                      # 解决方案文件
```

## 核心模块

### MainForm.cs
主窗体模块，负责：
- PHP/Server/Database 版本选择
- 服务启动/停止控制
- 配置加载和管理

### Tool.cs
工具类，提供：
- CMD 命令执行
- 进程管理（启动/关闭服务）
- 文件操作辅助

### XmlExt.cs
配置解析模块，用于读取和管理 XML 配置文件

## 环境要求

- Windows 操作系统
- .NET Framework 4.0+
- 本程序目录下需要包含以下目录结构

## 依赖目录结构

将 PHP、MySQL、Nginx 等依赖放到程序根目录，目录结构如下：

```
php_env/
├── php_env/                      # 主程序目录
│   ├── app.exe                   # 主程序
│   ├── server/                   # Web 服务器
│   │   ├── nginx/                # Nginx 目录
│   │   │   ├── conf/             # 配置文件
│   │   │   │   └── nginx.conf
│   │   │   ├── nginx.exe
│   │   │   └── ...
│   │   └── caddy/                # Caddy 目录 (可选)
│   │       ├── Caddyfile
│   │       ├── caddy.exe
│   │       └── ...
│   ├── php/                      # PHP 多个版本
│   │   ├── php-5.3.29/
│   │   │   ├── php-cgi.exe
│   │   │   ├── php.ini
│   │   │   └── ...
│   │   ├── php-5.4.45/
│   │   ├── php-5.6.27/
│   │   └── php-7.0.x/            # 根据版本号命名
│   ├── mysql/                    # MySQL 数据库
│   │   └── bin/
│   │       ├── mysqld.exe
│   │       ├── my.ini
│   │       └── ...
│   ├── www/                      # 网站根目录
│   │   └── index.php
│   └── ...
```

### 目录说明

| 目录 | 说明 | 必需 |
|:---|:---|:---:|
| `server/nginx/` | Nginx 服务器 | 是 |
| `server/caddy/` | Caddy 服务器 | 否 |
| `php/php-5.3.29/` | PHP 5.3.29 | 是 |
| `php/php-5.4.45/` | PHP 5.4.45 | 是 |
| `php/php-5.6.27/` | PHP 5.6.27 | 是 |
| `php/php-7.0.x/` | PHP 7.0 | 否 |
| `mysql/bin/` | MySQL 数据库 | 是 |
| `www/` | 网站根目录 | 是 |

## Nginx 配置

修改 `*\server\nginx\conf\nginx.conf` 配置文件：

```nginx
server {
    listen       80;
    server_name  localhost;
    root         "F:\1\www";  # 修改为您的网站根目录
    index        index.php index.html;
    
    location ~ \.php$ {
        fastcgi_pass   127.0.0.1:9000;
        fastcgi_index  index.php;
        fastcgi_param  SCRIPT_FILENAME $document_root$fastcgi_script_name;
        include        fastcgi_params;
    }
}
```

## 下载地址

| 版本 | 下载地址 |
|:---|:---|
| PHP 5.3/5.4/5.6 | [微云下载](https://share.weiyun.com/ffc3be37439c36681d097bc9ebf08e7e) |
| PHP 5.3~7.0 全版本 | [百度网盘](http://pan.baidu.com/s/1mhSBZq4) |


## 许可证

MIT License
