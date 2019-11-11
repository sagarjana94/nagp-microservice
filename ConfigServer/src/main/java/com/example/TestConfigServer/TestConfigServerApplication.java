package com.example.TestConfigServer;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.config.server.EnableConfigServer;

@EnableConfigServer
@SpringBootApplication
public class TestConfigServerApplication {

	public static void main(String[] args) {
		SpringApplication.run(TestConfigServerApplication.class, args);
	}

}
