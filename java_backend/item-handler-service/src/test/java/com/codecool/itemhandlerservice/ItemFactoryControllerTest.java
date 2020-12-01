package com.codecool.itemhandlerservice;

import com.codecool.itemhandlerservice.controller.ItemController;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import static org.assertj.core.api.Assertions.assertThat;

@SpringBootTest
public class ItemFactoryControllerTest {

    @Autowired
    private ItemController itemController;

    @Test
    public void contextLoads() throws Exception {
        assertThat(itemController).isNotNull();
    }
}
