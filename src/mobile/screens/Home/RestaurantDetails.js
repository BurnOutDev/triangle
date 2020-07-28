import React from 'react';
import Container from '../../components/Container';
import PageHeader from '../../components/PageHeader';
import { Filter, Back } from '../../components/Icons';
import RestaurantList from '../../components/RestaurantList/RestaurantList';
import { View } from 'react-native';
import { Icon, TopNavigationAction, Button, Text, Divider } from '@ui-kitten/components';
import PageHeaderContainer from '../../components/PageHeaderContainer';
import { colors } from '../../variables/colors';
import { Svg, Line } from 'react-native-svg';
import Category from '../../components/Category/Category';
import CategoryList from '../../components/Category/CategoryList';
import axios from '../../axios';
import { Splash } from '../Screens';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';

const RestaurantDetails = (props) => {
    return (
        <Container>
            <Header />
            <Text category='h3' style={{ fontWeight: 'bold', paddingHorizontal: 16 }}>Menu</Text>
            <MenuSpecial title={'The Chef Special'} />
        </Container>
    )
}

const Header = (props) =>
    <PageHeaderContainer style={{ backgroundColor: colors.white }}>
        <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.green })} />
    </PageHeaderContainer>

const MenuSpecial = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get('Restaurant/Restaurants')

        setData(response.data)
    }

    return (
        <View style={{ paddingVertical: 8, paddingHorizontal: 16, backgroundColor: colors.creamy }}>
            <View style={{ flexDirection: 'row' }}>
                <StarIcon width={16} height={16} />
                <Divider style={{ marginHorizontal: 4 }} />
                <Text>{props.title}</Text>
                <Divider style={{ marginHorizontal: 4 }} />
                <Svg height="2" width="200" style={{ flexDirection: 'column', flex: 1, alignItems: 'center', alignSelf: 'center' }}>
                    <Line x1="0" y1="0" x2="200" y2="0" stroke="#FFB700" strokeWidth="3" />
                </Svg>
            </View>
            {data ? <MenuHorizontalList restaurants={data.restaurants} /> : <Splash />}
        </View>
    )
}

const BackIcon = (props) => (
    <Icon {...props} name='arrow-back' />
);


const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

export default RestaurantDetails