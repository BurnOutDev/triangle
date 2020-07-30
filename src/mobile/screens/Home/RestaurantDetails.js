import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking } from 'react-native';
import { Text, StyleService, Icon, Button } from '@ui-kitten/components';
import { Splash } from '../Screens';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart } from '../../components/Icons';
import Address from '../../components/Address';
import { TouchableOpacity } from 'react-native-gesture-handler';

const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

const RestaurantDetails = (props) => {

    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const restaurantId = 1

        const response = await axios.get(`Restaurant/Restaurant/${restaurantId}`)

        setData(response.data)
    }

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
            <Button appearance='ghost' status='basic' icon={() => ShareIcon({ fill: colors.white })} />
        </View>
    )

    const PictureFooter = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
            <View style={{ flexDirection: 'row', top: 20 }}>
                <PhotoIcon fill={colors.white} width='16' height='16' />
                <Text style={{ color: colors.white }}>168</Text>
            </View>

            <Button
                style={styles.iconButton}
                size='small'
                icon={Heart}
                appearance='ghost'
            />
        </View>
    )

    const DetailText = ({ name, link, value }) => (
        <View style={styles.detailTexts}>
            <Text appearance='hint'>{name}</Text>
            {link ? <TouchableOpacity onPress={() => Linking.openURL(link)}><Text style={{ color: colors.green }}>{value}</Text></TouchableOpacity> : <Text>{value}</Text>}
        </View>
    )

    return (
        data ? <Container>
            <ImageBackground
                style={styles.itemHeader}
                source={{ uri: data.image }}
            >
                <PictureHeader />

                <PictureFooter />
            </ImageBackground>

            <View style={{ padding: 8 }}>
                <Text category='h4' style={{ color: colors.green, fontWeight: 'bold' }}>{data.title}</Text>

                <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
                    <View>
                        <Text category='s1' appearance='hint' style={{ lineHeight: 24 }}>Unit 10, 2F, 123 York Street</Text>
                        <Text category='s1' appearance='hint' style={{ lineHeight: 24 }}>{data.cuisine} • $$</Text>
                    </View>
                    <View>
                        <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                            <StarIcon width={24} height={24} />
                            <Text category='h2' style={{ fontWeight: 'bold', paddingLeft: 4, color: colors.gold }}>4.9</Text>
                        </View>
                        <Text category='s1' appearance='hint'>{`${data.reviewsCount} reviews`}</Text>
                    </View>
                </View>

                <DetailText name='Average Cost' value='$20 - $50' />
                <DetailText name='Hours' value='Open now 7 am - 6 pm' />
                <DetailText color={colors.green} name='Phone' value='(+995) 568 144 133' link='tel:568144133' />
                <DetailText color={colors.green} name='Website' value='lolitarestaurant.ge' link='http://lolitarestaurant.ge' />
            </View>
        </Container> : <Splash />
    )
}


const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productList: {
        paddingVertical: 16,
    },
    productItem: {
        flex: 1,
        margin: 8,
        backgroundColor: 'background-basic-color-1',
    },
    itemHeader: {
        flex: 0.4,
        justifyContent: 'space-between',
        flexDirection: 'column',
        padding: 8
    },
    rating: {
        flexDirection: 'row',
        // alignSelf: 'flex-start',
        alignItems: 'center',
        marginRight: 10,
    },
    iconButton: {
        paddingHorizontal: 0,
        backgroundColor: colors.white,
        width: 16,
        borderRadius: 16,
        top: 20,

        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 2,
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.84,

        elevation: 5,

        alignSelf: 'flex-end',
        marginHorizontal: 16
    },
    detailTexts: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingVertical: 4
    }
});

export default RestaurantDetails