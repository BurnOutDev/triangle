import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CuisineList from './CuisineList'
import Axios from '../../axios'

const Cuisine = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await Axios.post('Restaurant/Cuisines')

        setData(response.data)
    }

    return (data &&
        <View style={{ margin: 15 }}>
            <Text category='h3'>Cuisine</Text>
            <CuisineList cuisines={data.cuisines} />
        </View>
    )
}

export default Cuisine