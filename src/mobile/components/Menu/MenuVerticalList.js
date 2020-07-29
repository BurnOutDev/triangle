import React, { useState, Fragment } from 'react'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService, Divider } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'
import { Star, MinusIcon, PlusIcon } from '../Icons'
import { TouchableOpacity } from 'react-native-gesture-handler'
import PriceTag from '../PriceTag'
import { colors } from '../../variables/colors'

const RenderProductItem = ({ item, onUpdate }) => {
    const [clicked, setClicked] = React.useState(false)

    const click = () => {
        setClicked(!clicked)
    }

    const onPlusButtonPress = () => {
        if (item.item.count) {
            item.item.count = item.item.count + 1
        } else {
            item.item.count = 1
        }
        onUpdate()
    }

    const onMinusButtonPress = () => {
        if (item.item.count) {
            item.item.count = item.item.count - 1
        } else {
            item.item.count = 0
        }
        onUpdate()
    }

    return (
        <ListItem
            style={styles.productItem}
            onPress={click}>
            <View style={styles.content}>
                <Text category='s1'>{item.item.name} <Count count={item.item.count} /></Text>
                <Text appearance='hint' category='s2'>
                    {item.item.description}
                </Text>
                <PriceTag price={item.item.price} count={item.item.count} />

                {clicked && <View>
                    <View style={styles.amountContainer}>
                        <Button
                            style={[styles.iconButton, styles.amountButton]}
                            size='tiny'
                            icon={MinusIcon}
                            appearance='outline'
                            onPress={onMinusButtonPress}

                        />
                        <Divider style={{ paddingHorizontal: 4 }} />
                        <Button
                            style={[styles.iconButton, styles.amountButton]}
                            size='tiny'
                            icon={PlusIcon}
                            appearance='outline'
                            onPress={onPlusButtonPress}
                        />
                    </View>
                </View>}
            </View>

            <ImageBackground
                style={styles.itemHeader}
                source={{ uri: item.item.imageUrl }}
                imageStyle={{ borderRadius: 9, flex: 1 }}
            />
        </ListItem >)
}


const Count = (props) => (
    <>
        {props.count > 0 && <Text category='s1' style={{ fontWeight: 'normal', color: colors.green }}>{` x${props.count}`}</Text>}
    </>
)

const MenuVerticalList = (props) => {
    const [update, setUpdate] = React.useState(false)

    const onUpdate = () => {
        setUpdate(!update)
        props.onChange()
    }

    return (<List
        contentContainerStyle={props.style}
        data={props.menuItems}
        renderItem={nfo => <RenderProductItem item={nfo} onUpdate={onUpdate} />}
        style={{ flex: 1 }}
        ListHeaderComponent={props.header}
        ItemSeparatorComponent={Divider}
        extraData={update}
    />
    )
}

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productItem: {
        flex: 1,
        paddingHorizontal: 16,
    },
    itemHeader: {
        height: 80,
        width: 80,
        marginLeft: 8
    },
    content: {
        flex: 1
    },

    amountContainer: {
        flex: 1,
        flexDirection: 'row',
        marginTop: 8,
        // left: 16,
        // bottom: 16,
    },
    amountButton: {
        borderRadius: 8
    },
    amount: {
        textAlign: 'center',
        width: 40,
    },
    removeButton: {
        right: 0,
    },
    iconButton: {
        paddingHorizontal: 0,
    },
});

export default MenuVerticalList