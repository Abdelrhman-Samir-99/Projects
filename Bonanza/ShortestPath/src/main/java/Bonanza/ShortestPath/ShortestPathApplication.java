package Bonanza.ShortestPath;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@RestController
@RequestMapping
public class ShortestPathApplication {

	public static void main(String[] args) {
		SpringApplication.run(ShortestPathApplication.class, args);
	}

	@GetMapping
	public String greeting() {
		return "Hello";
	}
}
